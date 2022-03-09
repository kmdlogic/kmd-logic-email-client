using System;

namespace Kmd.Logic.Email.Client.Types
{
    /// <summary>
    /// Exception class to handle email related errors.
    /// </summary>
    [Serializable]
    public class EmailException : Exception
    {
        /// <summary>
        /// Gets InnerMessage.
        /// </summary>
        public string InnerMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailException"/> class.
        /// </summary>
        public EmailException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public EmailException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerMessage">Inner exception message.</param>
        public EmailException(string message, string innerMessage)
            : base(message)
        {
            this.InnerMessage = innerMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception message.</param>
        public EmailException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
