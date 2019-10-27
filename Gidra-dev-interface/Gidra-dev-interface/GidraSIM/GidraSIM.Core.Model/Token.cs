using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    public class Token
    {
        /// <summary>
        /// Параметр качества
        /// </summary>
        public double Quality { get; set; } = 0.0;

        public Token(double initialQuality)
        {
            Quality = initialQuality;
        }
    }
}
