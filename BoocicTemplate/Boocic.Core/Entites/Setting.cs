using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Core.Entites
{
    public class Setting : BaseEntity
    {
        [StringLength(maximumLength: 25, MinimumLength = 5)]
        public string? Key { get; set; }
        [Required]
        [StringLength(maximumLength: 55, MinimumLength = 5)]
        public string Value { get; set; }
    }
}
