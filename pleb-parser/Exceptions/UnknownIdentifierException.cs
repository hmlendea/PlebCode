using System;

namespace PlebCode.Infrastructure.Exceptions
{
    public class UnknownIdentifierException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCode.Parser.Exceptions.UnknownIdentifierException"/> class.
        /// </summary>
        public UnknownIdentifierException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCode.Parser.Exceptions.UnknownIdentifierException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public UnknownIdentifierException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCode.Parser.Exceptions.UnknownIdentifierException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public UnknownIdentifierException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

