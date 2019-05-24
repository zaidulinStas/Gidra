using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Результат моделирования
    /// </summary>
    public class SimulationResult
    {
        /// <summary>
        /// Результирующее время моделирования
        /// </summary>
        public double? ModelingTime { get; set; }

        /// <summary>
        /// Закончилось ли моделирование успешно?
        /// </summary>
        public bool IsSuccess { get { return ModelingTime.HasValue; } }
    }
}
