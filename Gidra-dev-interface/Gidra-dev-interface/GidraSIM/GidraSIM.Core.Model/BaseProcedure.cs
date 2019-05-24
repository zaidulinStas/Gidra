using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    public abstract class BaseProcedure: IProcedure
    {
        /// <summary>
        /// Название процедуры
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список входящих соединений
        /// </summary>
        public IList<Connection> Inputs { get; set; } = new List<Connection>();

        /// <summary>
        /// Список выходящих соединений
        /// </summary>
        public IList<Connection> Outputs { get; set; } = new List<Connection>();

        /// <summary>
        /// Параметры процедуры
        /// </summary>
        public Dictionary<string, double> Parameters { get; set; } = new Dictionary<string, double>();

        /// <summary>
        /// Время начала выполнения процедуры
        /// </summary>
        public double? StartTime { get; private set; }

        /// <summary>
        /// Активность процедуры
        /// </summary>
        public bool IsActive => Inputs.All(x => x.Tokens.Any()) && Inputs.Any();


        /// <summary>
        /// Обновление 
        /// </summary>
        public void Update(double curTime)
        {
            if (!IsActive)
            {
                return;
            }

            if (!StartTime.HasValue)
            {
                if (!StartModeling(curTime))
                {
                    return;
                }
            }


            if (!OnUpdateModeling(curTime))
            {
                return;
            }

            EndModeling(curTime);
        }

        /// <summary>
        /// Начало моделирования 
        /// </summary>
        private bool StartModeling(double curTime)
        {
            StartTime = curTime;

            if (!OnStartModeling())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Функция, вызывающаяся при начале моделирования 
        /// </summary>
        protected abstract bool OnStartModeling();

        /// <summary>
        /// Обновление моделирования процедуры
        /// </summary>
        protected abstract bool OnUpdateModeling(double curTime);

        /// <summary>
        /// Конец моделирования процедуры
        /// </summary>
        private void EndModeling(double curTime)
        {
            var newToken = new Token();

            foreach (var input in Inputs)
            {
                input.Tokens.Dequeue();
            }

            foreach (var output in Outputs)
            {
                output.Tokens.Enqueue(newToken);
            }

            OnEndModeling();

            StartTime = null;
        }

        /// <summary>
        /// Функция, вызывающаяся при окончании моделирования 
        /// </summary>
        protected virtual bool OnEndModeling()
        {
            return true;
        }

        /// <summary>
        /// Функция для соединения двух процедур
        /// </summary>
        public bool Connect(BaseProcedure another)
        {
            if (Outputs.Any(x => x.End == another))
            {
                return false;
            }

            var newConnection = new Connection() { Begin = this, End = another };

            Outputs.Add(newConnection);
            another.Inputs.Add(newConnection);

            return true;
        }

        /// <summary>
        /// Функция, очищающая все токены из соединений процедуры 
        /// </summary>
        public void Flush()
        {
            foreach (var resource in Inputs.Concat(Outputs))
            {
                resource.Tokens.Clear();
            }
        }
    }
}
