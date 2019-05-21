using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.DataLayer.Models
{
    public class Resource
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
