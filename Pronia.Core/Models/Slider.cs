using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Core.Models
{
    public  class Slider:BaseEntity
    {
        public string ImgUrl { get; set; } = null!;
        [NotMapped]
        public IFormFile ImgFile { get; set; } = null!;
    }
}
