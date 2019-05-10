using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Общий класс процедура, выполняющей часть процесса проектировани
    /// </summary>
    public class Procedure : IProcedure
    {
        /// <summary>
        /// Название процедуры
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список входных соединений
        /// </summary>
        public IList<Connection> Inputs { get; } = new List<Connection>();

        /// <summary>
        /// Список выходных соединений
        /// </summary>
        public IList<Connection> Outputs { get; } = new List<Connection>();

        /// <summary>
        /// Параметры процедуры
        /// </summary>
        public Dictionary<string, double> Parameters { get; } = new Dictionary<string, double>();

        /// <summary>
        /// Ресурсы процедуры
        /// </summary>
        public IList<Resource> Resources { get; } = new List<Resource>();

        /// <summary>
        /// Функция зависимости времени выполнения
        /// </summary>
        public string TimeExpression { get; set; }

        /// <summary>
        /// Время начала выполнения процедуры
        /// </summary>
        public double? StartTime { get; private set; }

        /// <summary>
        /// Продолжительность процедуры
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// Активность процедуры
        /// </summary>
        public bool IsActive => Inputs.All(x => x.Tokens.Any());

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

            UpdateModeling(curTime);

            if (!UpdateModeling(curTime))
            {
                return;
            }

            EndModeling(curTime);
        }

        /// <summary>
        /// Начало моделирования процедуры
        /// </summary>
        private bool StartModeling(double curTime)
        {
            StartTime = curTime;

            if (!Resources.All(x => x.IsFree))
            {
                return false;
            }

            foreach (var resource in Resources)
            {
                resource.Use();
            }

            return true;
        }

        /// <summary>
        /// Обновление моделирования процедуры
        /// </summary>
        private bool UpdateModeling(double curTime)
        {
            var variables = Parameters
                .Select(x => new { x.Key, x.Value })
                .Concat(Resources.SelectMany(res => res.Parameters.Select(x => new { Key = $"{res.Name}.{x.Key}", x.Value })))
                .Concat(new[] { new { Key = "[x]", Value = curTime- StartTime.Value } });

            var processingTimeExpression = TimeExpression;

            foreach (var variable in variables)
            {
                processingTimeExpression.Replace(variable.Key, variable.Value.ToString());
            }

            return Convert.ToDouble(new Expression(processingTimeExpression).calculate(), null) > Duration;
        }

        /// <summary>
        /// Конец моделирования процедуры
        /// </summary>
        private void EndModeling(double curTime)
        {
            var newToken = new Token();

            foreach (var input in Inputs)
            {
                input.Tokens.Peek();
            }

            foreach (var input in Outputs.SelectMany(x => x.End.Inputs))
            {
                input.Tokens.Enqueue(newToken);
            }

            StartTime = null;
        }
    }
}
