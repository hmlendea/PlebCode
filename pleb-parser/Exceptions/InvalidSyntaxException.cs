using System;
using System.Runtime.Serialization;

namespace PlebCodeParser.Exceptions
{
    [Serializable]
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

        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCodeParser.Exceptions.InvalidSyntaxException"/> class.
        /// </summary>
        /// <param name="info">Info.</param>
        /// <param name="context">Context.</param>
        protected InvalidSyntaxException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

