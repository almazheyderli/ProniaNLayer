﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Core.Models
{
    public  class Category:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

    }
}
