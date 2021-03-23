using System;
using System.Runtime.Serialization;

namespace CodeDesignPlus.Event.Bus.Exceptions
{
    /// <summary>
    /// Se genera cuando se quiere acceder a un evento que no esta registrado
    /// </summary>
    [Serializable]
    public class EventNotExistException : Exception
    {

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventNotExistException"/>
        /// </summary>
        public EventNotExistException()
        {
        }

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventBusException"/>
        /// </summary>
        /// <param name="message">Mensaje del error</param>
        public EventNotExistException(string message) : base(message)
        {
        }

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventNotExistException"/>
        /// </summary>
        /// <param name="message">Mensaje del error</param>
        /// <param name="innerException">Inner Exception</param>
        public EventNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Without this constructor, deserialization will fail
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected EventNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
