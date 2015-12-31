﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVT.Models
{
    public class Project
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool isActive { get; set; }
    }
}