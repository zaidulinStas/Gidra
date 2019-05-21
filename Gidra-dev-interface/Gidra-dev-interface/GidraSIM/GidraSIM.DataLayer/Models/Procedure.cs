using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.DataLayer.Models
{
    public class Procedure
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ProgressFunction { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
