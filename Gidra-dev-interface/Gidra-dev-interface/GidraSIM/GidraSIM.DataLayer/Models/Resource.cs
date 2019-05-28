﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.DataLayer.Models
{
    public class Resource
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double Cost { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
