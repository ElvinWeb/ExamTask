using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Core.Entites
{
    public class Service : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 4)]
        public string Category { get; set; }

        [StringLength(maximumLength: 100)]
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
