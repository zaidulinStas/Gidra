﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.DataLayer.Models
{
    public class Parameter
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public double Value { get; set; }
    }
}