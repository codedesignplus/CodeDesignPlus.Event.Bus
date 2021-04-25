using CodeDesignPlus.Event.Bus.Abstractions;
using CodeDesignPlus.Event.Bus.Exceptions;
using System;
using System.Collections.Generic;

namespace CodeDesignPlus.Event.Bus
{
    /// <summary>
    /// Servicio para administrar las suscripciones de eventos 
    /// </summary>
    public interface ISubscriptionManager
    {
        /// <summary>
        /// Determines whether a sequence contains any elements.
        /// </summary>
        bool Any();
        /// <summary>
        /// An event fired if an event has removed
        /// </summary>
        event EventHandler<Subscription> OnEventRemoved;
        /// <summary>
        /// Gets the name of the event from TEvent
        /// </summary>
        /// <typeparam name="TEvent">Type Event from which the name must be obtained</typeparam>
        /// <returns>Returns the name of the event</returns>
        string GetEventKey<TEvent>() where TEvent : EventBase;
        /// <summary>
        /// Add the generic types in the Suscription Manager
        /// </summary>
        /// <typeparam name="TEvent">The type of the event</typeparam>
        /// <typeparam name="TEventHandler">The type of the event handler</typeparam>
        /// <exception cref="EventHandlerAlreadyRegisteredException{TEvent, TEventHandler}"></exception>
        void AddSubscription<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>;
        /// <summary>
        /// Metodo encargado de remover un manejador de eventos del administrador de suscripciones
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a remover</typeparam>
        /// <typeparam name="TEventHandler">Manejador de eventos de integración (Callback)</typeparam>
        void RemoveSubscription<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>;
        /// <summary>
        /// Metodo encargado de validar si exiten manejadores de eventos registrados para un determinado evento de integración
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a validar si tiene un manejador de eventos asociado</typeparam>
        /// <returns>Retorna true si el evento de integración tiene un manejador de evento asociado</returns>
        bool HasSubscriptionsForEvent<TEvent>() where TEvent : EventBase;

        /// <summary>
        /// Metodo encargado de obtener la inforamción de un evento de integración
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a consultar</typeparam>
        /// <exception cref="ArgumentNullException">El nombre del evento no es valido </exception>
        /// <exception cref="EventNotExistException">El evento especificado no se encuentra registrado</exception>
        /// <returns>Retorna la información de la suscripción de un evento</returns>
        IEnumerable<Subscription> GetHandlers<TEvent>() where TEvent : EventBase;
        /// <summary>
        /// Metodo encargado de buscar y retornar la información de la suscripción a partir del nombre y tipo del evento
        /// </summary>
        /// <typeparam name="TEvent">Tipo del Evento a buscar</typeparam>
        /// <typeparam name="TEventHandler">Tipo del manejador de eventos a buscar</typeparam>
        /// <returns>Retorna la información con la que se suscribió el evento, en caso de no encontrar el evento, este retornara null</returns>
        Subscription FindSubscription<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>;

        /// <summary>
        /// Metodo encargado de buscar y retornar la información de la suscripción a partir del nombre y tipo del evento
        /// </summary>
        /// <typeparam name="TEvent">Tipo del Evento a buscar</typeparam>
        /// <typeparam name="TEventHandler">Tipo del manejador de eventos a buscar</typeparam>
        /// <returns>Retorna la información con la que se suscribió el evento, en caso de no encontrar el evento, este retornara null</returns>
        List<Subscription> FindSubscriptions<TEvent>()
            where TEvent : EventBase;

        /// <summary>
        /// Metodo encargado de limpiar el administrador de suscripciones
        /// </summary>
        void Clear();
    }
}
