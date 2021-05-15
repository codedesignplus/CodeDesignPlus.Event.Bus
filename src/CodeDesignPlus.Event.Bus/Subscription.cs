using CodeDesignPlus.Event.Bus.Abstractions;
using System;

namespace CodeDesignPlus.Event.Bus
{
    /// <summary>
    /// Información relacionada con el evento que se esta registrando en <see cref="SubscriptionManager"/>
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Nombre del Evento
        /// </summary>
        public string EventName { get => this.EventType.Name; }
        /// <summary>
        /// Expone el <see cref="Type"/> del manejador de eventos
        /// </summary>
        public Type EventType { get; }
        /// <summary>
        /// Expone el <see cref="Type"/> del manejador de eventos
        /// </summary>
        public Type EventHandlerType { get; }

        /// <summary>
        /// Crea una nueva instancia de <see cref="Subscription"/>
        /// </summary>
        /// <param name="eventHandlerType"><see cref="Type"/> del manejador de eventos</param>
        private Subscription(Type eventType, Type eventHandlerType)
        {
            this.EventType = eventType;
            this.EventHandlerType = eventHandlerType;
        }

        /// <summary>
        /// Metodo encargado de construir la información de un evento
        /// </summary>
        /// <typeparam name="TEvent">Evento de Integración</typeparam>
        /// <typeparam name="TEventHandler">Manejador de eventos</typeparam>
        /// <returns>Retorna la información del evento</returns>
        public static Subscription Create<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>
        {
            return new Subscription(typeof(TEvent), typeof(TEventHandler));
        }
    }
}
