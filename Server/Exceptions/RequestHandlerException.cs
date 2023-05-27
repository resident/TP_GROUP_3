using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Exceptions
{
    public class RequestHandlerException : Exception
    {
        public RequestHandlerException()
        {
        }

        public RequestHandlerException(string message) : base(message)
        {
        }

        public RequestHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
