using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boocic.Business.CustomExceptions.ServiceImage
{
    public class InvalidImageContentTypeOrSizeException : Exception
    {
        public string PropertyName { get; set; }
        public InvalidImageContentTypeOrSizeException()
        {
        }

        public InvalidImageContentTypeOrSizeException(string? message) : base(message)
        {
        }
        public InvalidImageContentTypeOrSizeException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
