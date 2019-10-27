using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Параметры моделирования
    /// </summary>
    public class SimulationOptions
    {
        /// <summary>
        /// Максимальное время моделирования
        /// </summary>
        public double MaxTime { get; set; } = 20000000;

        /// <summary>
        /// Шаг моделирования
        /// </summary>
        public double SimulationStep { get; set; } = 10.0;

        /// <summary>
        /// Список процедур
        /// </summary>
        public List<BaseProcedure> Procedures { get; set; } = new List<BaseProcedure>();

        /// <summary>
        /// Токен, который будет подан на вход схемы
        /// </summary>
        public Token StartToken { get; set; } = new Token();
    }
}
