using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Core.Entites
{
    public class Service : BaseEntity
    {
        public string Category { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
