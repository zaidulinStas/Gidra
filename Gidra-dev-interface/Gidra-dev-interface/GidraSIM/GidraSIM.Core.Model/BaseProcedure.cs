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
        /// Список соединений обратной связи
        /// </summary>
        public IList<Connection> BackLinks { get; set; } = new List<Connection>();

        /// <summary>
        /// Ресурсы процедуры, включая все вложенные
        /// </summary>
        public abstract IList<Resource> AllResources { get; }

        /// <summary>
        /// Параметры процедуры
        /// </summary>
        public Dictionary<string, double> Parameters { get; set; } = new Dictionary<string, double>();

        /// <summary>
        /// Время начала выполнения процедуры
        /// </summary>
        public double? StartTime { get; private set; }

        /// <summary>
        /// Минимально необходимая величина входного качества (от 0 до MaxQuality). 
        /// </summary>
        public double MinQuality { get; set; }

        /// <summary>
        /// Максимально возможная величина выходного качества (от MinQuality до 1)
        /// </summary>
        public double MaxQuality { get; set; }

        /// <summary>
        /// Активность процедуры
        /// </summary>
        public bool IsActive => Inputs.All(x => x.Tokens.Any()) && Inputs.Any();

        /// <summary>
        /// Условие выполнения процедуры - входное качество должно быть больше минимального, иначе - возврат по обратной связи
        /// </summary>
        public bool IsQualityHigherEnough =>  Inputs.Any() && Inputs[0].Tokens.Peek().Quality >= MinQuality;

        /// <summary>
        /// Целевое качество, которое нужно достичь. Является случайной величиной от величины входного качества до MaxQuality
        /// </summary>
        protected double _targetQuality;

        /// <summary>
        /// Входное качество. Определяется качеством входного токена
        /// </summary>
        protected double _interQuality;

        /// <summary>
        /// Обновление 
        /// </summary>
        public ProcedureSimulationResult Update(double curTime)
        {
            if (!IsActive)
            {
                return null;
            }

            if(!IsQualityHigherEnough)
            {
                BackLinkReturn(curTime);

                return null;
            }

            if (!StartTime.HasValue)
            {
                if (!StartModeling(curTime))
                {
                    return null;
                }
            }


            if (!OnUpdateModeling(curTime))
            {
                return null;
            }

            return EndModeling(curTime);
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

            Random rnd = new Random();

            _interQuality = Inputs[0].Tokens.Peek().Quality;

            _targetQuality = _interQuality + rnd.NextDouble() * (MaxQuality - _interQuality);

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
        private ProcedureSimulationResult EndModeling(double curTime)
        {
            //var referenceToken = Inputs[0].Tokens.Peek();

            foreach (var input in Inputs)
            {
                input.Tokens.Dequeue();
            }

            foreach (var output in Outputs)
            {
                var newToken = new Token(_targetQuality);

                output.Tokens.Enqueue(newToken);
            }

            OnEndModeling();

            var result = new ProcedureSimulationResult
            {
                StartTime = (StartTime.HasValue) ? StartTime.Value : curTime,
                EndTime = curTime,
                IsBackLink = false,
                ResultQuality = _targetQuality
            };

            StartTime = null;

            return result;
        }

        /// <summary>
        /// Возврат по обратной связи
        /// </summary>
        private ProcedureSimulationResult BackLinkReturn(double curTime)
        {
            var newToken = Inputs[0].Tokens.Peek();

            foreach (var input in Inputs)
            {
                input.Tokens.Dequeue();
            }

            foreach (var backlink in BackLinks)
            {
                backlink.End.Inputs[0].Tokens.Enqueue(new Token(newToken.Quality));
            }

            //OnEndModeling();

            var result = new ProcedureSimulationResult
            {
                StartTime = (StartTime.HasValue) ? StartTime.Value : curTime,
                EndTime = curTime,
                IsBackLink = true,
                ResultQuality = newToken.Quality
            };

            StartTime = null;

            return result;
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
        /// Функция для соединения двух процедур обратной связью
        /// </summary>
        public bool BackLinkConnect(BaseProcedure another)
        {
            if (BackLinks.Any(x => x.End == another))
            {
                return false;
            }

            var newConnection = new Connection() { Begin = this, End = another };

            BackLinks.Add(newConnection);
            //another.Inputs.Add(newConnection);

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
