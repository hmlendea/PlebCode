using System;

namespace PlebCode.Infrastructure.Exceptions
{
    public class InvalidSyntaxException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCodeParser.Exceptions.InvalidSyntaxException"/> class.
        /// </summary>
        public InvalidSyntaxException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCodeParser.Exceptions.InvalidSyntaxException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public InvalidSyntaxException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCodeParser.Exceptions.InvalidSyntaxException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidSyntaxException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

