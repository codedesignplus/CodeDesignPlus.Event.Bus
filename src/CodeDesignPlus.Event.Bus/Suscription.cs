﻿using CodeDesignPlus.Event.Bus.Abstractions;
using System;

namespace CodeDesignPlus.Event.Bus
{
    /// <summary>
    /// Información relacionada con el evento que se esta registrando en <see cref="SuscriptionManager"/>
    /// </summary>
    public class Suscription
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
        /// Crea una nueva instancia de <see cref="Suscription"/>
        /// </summary>
        /// <param name="eventHandlerType"><see cref="Type"/> del manejador de eventos</param>
        private Suscription(Type eventType, Type eventHandlerType)
        {
            this.EventType = eventType;
            this.EventHandlerType = eventHandlerType;
        }

        /// <summary>
        /// Metodo encargado de construir la información de un evento
        /// </summary>
        /// <param name="eventHandlerType"><see cref="Type"/> del manejador de eventos</param>
        /// <returns>Retorna la información del evento</returns>
        public static Suscription Create<TEvent, TEventHandler>() 
            where TEvent: EventBase 
            where TEventHandler: IEventHandler<TEvent>
        {
            return new Suscription(typeof(TEvent), typeof(TEventHandler));
        }
    }
}
