using System;

namespace Fnx.Core.Exceptions
{
    /// <summary>
    /// The exception that is thrown to indicate that the element being requested does not exist.
    /// </summary>
    public class NoSuchElementException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the NoSuchElementException class with a default error message.
        /// </summary>
        public NoSuchElementException() : base(ExceptionsMessages.NoSuchElement)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NoSuchElementException class with a specified error message.
        /// </summary>
        public NoSuchElementException(string message) : base(message)
        {
        }
    }
}