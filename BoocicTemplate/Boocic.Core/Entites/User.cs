using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Core.Entites
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 6)]
        public string Fullname { get; set; }
    }
}
