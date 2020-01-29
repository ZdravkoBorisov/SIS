using System;

namespace SIS.Http
{
    public class HttpServerException : Exception
    {
        public HttpServerException(string message) 
            : base(message)
        {
        }
    }
}
