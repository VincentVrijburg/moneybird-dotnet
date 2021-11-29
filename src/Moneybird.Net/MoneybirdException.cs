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

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneybirdException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        public MoneybirdException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}