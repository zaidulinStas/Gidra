using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Общий класс процедуры, выполняющей часть процесса проектировани
    /// </summary>
    public class Procedure : BaseProcedure
    {
        /// <summary>
        /// Ресурсы процедуры
        /// </summary>
        public IList<Resource> Resources { get; set; } = new List<Resource>();

        /// <summary>
        /// Ресурсы процедуры, включая все вложенные
        /// </summary>
        public override IList<Resource> AllResources => Resources;

        /// <summary>
        /// Функция зависимости времени выполнения. Вместо [x] податвляется текущее время выполнения процедуры. 
        /// Если значение функции больше 1.0, то процедурf считается выполненной
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
            var token = Inputs[0].Tokens.Peek();

            var variables = Parameters
                .Select(x => new { Key=$"[{x.Key}]", x.Value })
                .Concat(Resources.SelectMany(res => res.Parameters.Select(x => new { Key = $"[{res.Type}.{x.Key}]", x.Value })))
                .Concat(new[] { new { Key = "[x]", Value = curTime - StartTime.Value } });

            var expression = ProgressFunction;

            foreach (var variable in variables)
            {
                expression = expression.Replace(variable.Key, variable.Value.ToString(CultureInfo.InvariantCulture.NumberFormat));
            }

            var matches = Regex.Matches(expression, @"rnd\([^\)\(]*,[^\)\(]*\)", RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    var parts = Regex.Replace(capture.Value, @"rnd\(", "", RegexOptions.IgnoreCase)
                                     .Replace(")", "")
                                     .Replace(" ", "")
                                     .Split(',');

                    var rnd = new Random(DateTime.Now.Millisecond);
                    var randomValue = double.Parse(parts[0]) + rnd.NextDouble() * double.Parse(parts[1]);
                    expression = expression.Replace(capture.Value, randomValue.ToString(CultureInfo.InvariantCulture.NumberFormat));
                }
            }

            var qualityIncrement = Convert.ToDouble(new Expression(expression).calculate(), null);

            return qualityIncrement >= (_targetQuality - _interQuality);
        }

        /// <summary>
        /// Функция, вызывающаяся при окончании моделирования 
        /// </summary>
        protected override bool OnEndModeling()
        {
            foreach (var resource in Resources)
            {
                resource.Release();
            }

            return true;
        }
    }
}
