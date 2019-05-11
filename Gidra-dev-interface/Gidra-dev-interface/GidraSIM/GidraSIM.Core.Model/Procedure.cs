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
    public class Procedure : BaseProcedure
    {
        /// <summary>
        /// Ресурсы процедуры
        /// </summary>
        public IList<Resource> Resources { get; } = new List<Resource>();

        /// <summary>
        /// Функция зависимости времени выполнения
        /// </summary>
        public string ProgressFunction { get; set; }


        /// <summary>
        /// Функция, вызывающаяся при начале моделирования 
        /// </summary>
        protected override bool OnStartModeling()
        {
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
        protected override bool OnUpdateModeling(double curTime)
        {
            var variables = Parameters
                .Select(x => new { x.Key, x.Value })
                .Concat(Resources.SelectMany(res => res.Parameters.Select(x => new { Key = $"{res.Name}.{x.Key}", x.Value })))
                .Concat(new[] { new { Key = "[x]", Value = curTime - StartTime.Value } });

            var expression = ProgressFunction;

            foreach (var variable in variables)
            {
                expression.Replace(variable.Key, variable.Value.ToString());
            }

            return Convert.ToDouble(new Expression(expression).calculate(), null) > 1.0;
        }
    }
}
