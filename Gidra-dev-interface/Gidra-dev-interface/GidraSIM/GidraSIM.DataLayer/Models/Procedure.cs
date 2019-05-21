using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.DataLayer.Models
{
    public class Procedure
    {
        public string Id { get; set; }

        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public string ProgressFunction { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
