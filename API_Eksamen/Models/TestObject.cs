﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Eksamen.Models
{
    public class TestObject
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Posted { get; set; }
    }
}
