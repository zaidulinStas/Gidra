using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Результат моделирования процедуры
    /// </summary>
    public class ProcedureSimulationResult
    {
        /// <summary>
        /// Начало моделирования
        /// </summary>
        public double StartTime { get; set; }

        /// <summary>
        /// Конец моделирования
        /// </summary>
        public double EndTime { get; set; }

        /// <summary>
        /// Продолжительность моделирования
        /// </summary>
        public double Duration => EndTime - StartTime;

        /// <summary>
        /// Обратная связь
        /// </summary>
        public bool IsBackLink { get; set; }

        /// <summary>
        /// Выходное качество
        /// </summary>
        public double StartQuality { get; set; }

        /// <summary>
        /// Выходное качество
        /// </summary>
        public double ResultQuality { get; set; }
    }
}
