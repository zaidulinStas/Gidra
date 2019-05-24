using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    public class SimulationLog
    {
        public Procedure Procedure { get; set; }

        public ProcedureSimulationResult SimulationResult { get; set; }
    }
}
