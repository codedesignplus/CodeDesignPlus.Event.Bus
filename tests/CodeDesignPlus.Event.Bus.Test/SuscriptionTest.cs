using CodeDesignPlus.Event.Bus.Test.Helpers;
using System;
using Xunit;

namespace CodeDesignPlus.Event.Bus.Test
{
    /// <summary>
    /// Pruebas unitarias a la clase <see cref="Subscription"/>
    /// </summary>
    public class SuscriptionTest
    {
        /// <summary>
        /// Event Handler que procesa los eventos de tipo <see cref="UserCreatedEvent"/>
        /// </summary>
        private readonly UserEventHandler userEventHandler;
        /// <summary>
        /// Evento de integración usado cuando es creado un usuarios
        /// </summary>
        private readonly UserCreatedEvent userCreatedEvent;

        /// <summary>
        /// Crea una nueva instancia de <see cref="SuscriptionTest"/>
        /// </summary>
        public SuscriptionTest()
        {
            this.userCreatedEvent = new UserCreatedEvent()
            {
                Id = new Random().Next(1, 1000),
                Age = (ushort)new Random().Next(1, 100),
                Name = nameof(UserCreatedEvent.Name),
                User = nameof(UserCreatedEvent.User),
            };

            this.userEventHandler = new UserEventHandler();
        }

        /// <summary>
        /// Valida que se inicie correctamente el estado del objeto
        /// </summary>
        public void Create_InitializeStateObject_GetPropertiesValue()
        {
            // Arrange
            var eventType = this.userCreatedEvent.GetType();
            var eventHandlerType = this.userEventHandler.GetType();

            // Act
            var subscription = Subscription.Create<UserCreatedEvent, UserEventHandler>();

            // Assert
            Assert.Equal(eventType, subscription.EventType);
            Assert.Equal(eventHandlerType, subscription.EventHandlerType);
            Assert.Equal(eventHandlerType.Name, subscription.EventName);
        }
    }
}
