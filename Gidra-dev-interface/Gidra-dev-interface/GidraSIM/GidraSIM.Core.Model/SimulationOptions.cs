using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    public class SimulationOptions
    {
        public double MaxTime { get; set; } = 200000;

        public double SimulationStep { get; set; } = 1.0;

        public List<Procedure> Procedures { get; set; } = new List<Procedure>();

        public Token StartToken { get; set; } = new Token();
    }
}
