using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Общий класс ресурса, используемого в процедурах
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Название ресурса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип ресурса
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Стоимость ресурса
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Параметры ресурса
        /// </summary>
        public Dictionary<string, double> Parameters { get; set; } = new Dictionary<string, double>();

        /// <summary>
        /// Максимальное число одновременного использования ресурса
        /// </summary>
        public int MaxUsageCount { get; set; } = 1;

        /// <summary>
        /// Текущее количество использований ресурса
        /// </summary>
        public int CurUsageCount { get; private set; }

        /// <summary>
        /// Свободен ли ресурс?
        /// </summary>
        public bool IsFree => CurUsageCount + 1 <= MaxUsageCount;

        /// <summary>
        /// Использовние ресурса
        /// </summary>
        public void Use()
        {
            //if (!IsFree)
            //{
            //    throw new InvalidOperationException("Ресурс занят");
            //}

            CurUsageCount++;
        }

        /// <summary>
        /// Освобождение ресурса
        /// </summary>
        public void Release()
        {
            //if (CurUsageCount <= 0)
            //{
            //    throw new InvalidOperationException("Ресурс свободен");
            //}

            CurUsageCount--;
        }
    }
}
