using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business.CustomExceptions.Common
{
    public class InvalidIdOrBlowThanZeroException : Exception
    {
        public string PropertyName { get; set; }
        public InvalidIdOrBlowThanZeroException()
        {
        }

        public InvalidIdOrBlowThanZeroException(string? message) : base(message)
        {
        }
        public InvalidIdOrBlowThanZeroException(string propName , string? message) : base(message)
        {
            PropertyName = propName;
        }

    }
}
