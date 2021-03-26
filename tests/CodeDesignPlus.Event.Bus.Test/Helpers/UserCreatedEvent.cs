﻿using CodeDesignPlus.Event.Bus.Abstractions;
using System;

namespace CodeDesignPlus.Event.Bus.Test.Helpers
{
    /// <summary>
    /// Evento de integración usado cuando es creado un usuarios
    /// </summary>
    public class UserCreatedEvent: EventBase
    {
        /// <summary>
        /// Crea una nueva instancia de <see cref="UserCreatedEvent"/>
        /// </summary>
        public UserCreatedEvent()
        {
        }

        /// <summary>
        /// Crea una nueva instancia de <see cref="UserCreatedEvent"/>
        /// </summary>
        /// <param name="idEvent">Id Event</param>
        /// <param name="eventDate">Date the event was generated</param>
        /// <exception cref="ArgumentOutOfRangeException">The assigned date is invalid</exception>
        public UserCreatedEvent(Guid idEvent, DateTime eventDate) : base(idEvent, eventDate)
        {
        }

        /// <summary>
        /// Id del usaurio
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nombre del usuario creado
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Edad del usuario
        /// </summary>
        public ushort Age { get; set; }
    }
}
