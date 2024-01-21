using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Core.Entites
{
    public class Service : BaseEntity
    {
        public string Category { get; set; }
        public string? ImgUrl { get; set; }
        public IFormFile? Image { get; set; }
    }
}
