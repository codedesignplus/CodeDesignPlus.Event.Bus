using System;
using System.Runtime.Serialization;

namespace CodeDesignPlus.Event.Bus.Exceptions
{
    /// <summary>
    /// Se genera cuando se quiere acceder a un evento que no esta registrado
    /// </summary>
    [Serializable]
    public class EventNotImplementedException : Exception
    {

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventNotImplementedException"/>
        /// </summary>
        public EventNotImplementedException()
        {
        }

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventBusException"/>
        /// </summary>
        /// <param name="message">Mensaje del error</param>
        public EventNotImplementedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventNotImplementedException"/>
        /// </summary>
        /// <param name="message">Mensaje del error</param>
        /// <param name="innerException">Inner Exception</param>
        public EventNotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Without this constructor, deserialization will fail
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected EventNotImplementedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
