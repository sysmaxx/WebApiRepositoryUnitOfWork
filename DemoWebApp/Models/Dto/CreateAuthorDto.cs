﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Models.Dto
{
    public class CreateAuthorDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
