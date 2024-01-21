using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business.CustomExceptions.Common
{
    public class InvalidEntityException : Exception
    {

        public string PropertyName { get; set; }
        public InvalidEntityException()
        {
        }

        public InvalidEntityException(string? message) : base(message)
        {
        }
        public InvalidEntityException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
