﻿using System;
using System.Runtime.Serialization;

namespace CodeDesignPlus.Event.Bus.Exceptions
{
    /// <summary>
    /// This exception that is thrown when an event handler is not registered in the subscription manager
    /// </summary>
    [Serializable]
    public class EventIsNotRegisteredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the EventHandlerAlreadyRegisteredException class.
        /// </summary>
        public EventIsNotRegisteredException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the EventHandlerAlreadyRegisteredException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public EventIsNotRegisteredException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the EventHandlerAlreadyRegisteredException class with a specified error message 
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public EventIsNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Without this constructor, deserialization will fail
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected EventIsNotRegisteredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
