using CodeDesignPlus.Event.Bus.Abstractions;
using CodeDesignPlus.Event.Bus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeDesignPlus.Event.Bus
{
    /// <summary>
    /// Implementación por defecto del servicio <see cref="ISubscriptionManager"/>
    /// </summary>
    public class SubscriptionManager : ISubscriptionManager
    {
        /// <summary>
        /// Relationship between the event name and its multiple handlers
        /// </summary>
        private readonly Dictionary<string, List<Subscription>> handlers = new Dictionary<string, List<Subscription>>();

        /// <summary>
        /// Determines whether a sequence contains any elements.
        /// </summary>
        public bool Any() => this.handlers.Any();

        /// <summary>
        /// An event fired if an event has removed
        /// </summary>
        public event EventHandler<Subscription> OnEventRemoved;

        /// <summary>
        /// Gets the name of the event from TEvent
        /// </summary>
        /// <typeparam name="TEvent">Type Event from which the name must be obtained</typeparam>
        /// <returns>Returns the name of the event</returns>
        public string GetEventKey<TEvent>() where TEvent : EventBase => typeof(TEvent).Name;

        /// <summary>
        /// Add the generic types in the Suscription Manager
        /// </summary>
        /// <typeparam name="TEvent">The type of the event</typeparam>
        /// <typeparam name="TEventHandler">The type of the event handler</typeparam>
        /// <exception cref="EventHandlerAlreadyRegisteredException{TEvent, TEventHandler}"></exception>
        public void AddSubscription<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>
        {
            var eventName = this.GetEventKey<TEvent>();

            if (!this.HasSubscriptionsForEvent<TEvent>())
                this.handlers.Add(eventName, new List<Subscription>());

            if (this.handlers[eventName].Any(x => x.EventHandlerType == typeof(TEventHandler)))
                throw new EventHandlerAlreadyRegisteredException<TEvent, TEventHandler>();

            this.handlers[eventName].Add(Subscription.Create<TEvent, TEventHandler>());
        }

        /// <summary>
        /// Metodo encargado de remover un manejador de eventos del administrador de suscripciones
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a remover</typeparam>
        /// <typeparam name="TEventHandler">Manejador de eventos de integración (Callback)</typeparam>
        public void RemoveSubscription<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>
        {
            var eventName = GetEventKey<TEvent>();
            var suscription = this.FindSubscription<TEvent, TEventHandler>();

            if (suscription != null)
            {
                this.handlers[eventName].Remove(suscription);

                if (!this.handlers[eventName].Any())
                {
                    this.handlers.Remove(eventName);

                    this.OnEventRemoved?.Invoke(this, suscription);
                }
            }
        }

        /// <summary>
        /// Metodo encargado de validar si exiten manejadores de eventos registrados para un determinado evento de integración
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a validar si tiene un manejador de eventos asociado</typeparam>
        /// <returns>Retorna true si el evento de integración tiene un manejador de evento asociado</returns>
        public bool HasSubscriptionsForEvent<TEvent>() where TEvent : EventBase
        {
            var eventName = this.GetEventKey<TEvent>();

            return this.handlers.ContainsKey(eventName);
        }

        /// <summary>
        /// Metodo encargado de obtener la inforamción de un evento de integración
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a consultar</typeparam>
        /// <exception cref="ArgumentNullException">El nombre del evento no es valido </exception>
        /// <exception cref="EventNotExistException">El evento especificado no se encuentra registrado</exception>
        /// <returns>Retorna la información de la suscripción de un evento</returns>
        public IEnumerable<Subscription> GetHandlers<TEvent>() where TEvent : EventBase
        {
            var eventName = this.GetEventKey<TEvent>();

            if (!this.handlers.ContainsKey(eventName))
                throw new EventIsNotRegisteredException();

            return this.handlers[eventName];
        }

        /// <summary>
        /// Metodo encargado de buscar y retornar la información de la suscripción a partir del nombre y tipo del evento
        /// </summary>
        /// <typeparam name="TEvent">Tipo del Evento a buscar</typeparam>
        /// <typeparam name="TEventHandler">Tipo del manejador de eventos a buscar</typeparam>
        /// <returns>Retorna la información con la que se suscribió el evento, en caso de no encontrar el evento, este retornara null</returns>
        public Subscription FindSubscription<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>
        {
            var eventName = this.GetEventKey<TEvent>();

            if (!this.HasSubscriptionsForEvent<TEvent>())
                throw new EventIsNotRegisteredException();

            return this.handlers[eventName].SingleOrDefault(s => s.EventHandlerType == typeof(TEventHandler));
        }

        /// <summary>
        /// Metodo encargado de buscar y retornar la información de la suscripción a partir del nombre y tipo del evento
        /// </summary>
        /// <typeparam name="TEvent">Tipo del Evento a buscar</typeparam>
        /// <returns>Retorna la información con la que se suscribió el evento, en caso de no encontrar el evento, este retornara null</returns>
        public List<Subscription> FindSubscriptions<TEvent>()
            where TEvent : EventBase
        {
            var eventName = this.GetEventKey<TEvent>();

            if (!this.HasSubscriptionsForEvent<TEvent>())
                throw new EventIsNotRegisteredException();

            return this.handlers[eventName];
        }

        /// <summary>
        /// Metodo encargado de limpiar el administrador de suscripciones
        /// </summary>
        public void Clear() => this.handlers.Clear();
    }
}
