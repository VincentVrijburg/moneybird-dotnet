using System;
using System.Net;

namespace Moneybird.Net
{
    public class MoneybirdException : Exception
    {
        /// <summary>
        /// The HTTP error code returned by the Moneybird API, causing this exception.
        /// </summary>
        public readonly HttpStatusCode HttpStatusCode;

        public MoneybirdException(string message) : base(message)
        {
        }
        
        public MoneybirdException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
