﻿using System;
using First_Project.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace First_Project.Data.Master
{
    public class Religion:Base
    {
        [Required]
        [Column(TypeName = "NVARCHAR(150)")]
        public string name { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        public string shortName { get; set; }
    }
}