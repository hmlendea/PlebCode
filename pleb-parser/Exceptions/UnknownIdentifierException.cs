using System;
using System.Runtime.Serialization;

namespace PlebCodeParser.Exceptions
{
    [Serializable]
    public class UnknownIdentifierException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCodeParser.Exceptions.UnknownIdentifierException"/> class.
        /// </summary>
        public UnknownIdentifierException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCodeParser.Exceptions.UnknownIdentifierException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public UnknownIdentifierException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCodeParser.Exceptions.UnknownIdentifierException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public UnknownIdentifierException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlebCodeParser.Exceptions.UnknownIdentifierException"/> class.
        /// </summary>
        /// <param name="info">Info.</param>
        /// <param name="context">Context.</param>
        protected UnknownIdentifierException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

