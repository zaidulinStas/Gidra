using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.DataLayer.Models
{
    public class Parameter
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Key { get; set; }

        [Required]
        public double Value { get; set; }
    }
}
