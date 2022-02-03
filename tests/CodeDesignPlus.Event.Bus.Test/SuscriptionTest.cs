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
        /// Event Handler que procesa los eventos de tipo <see cref="UserRegisteredEvent"/>
        /// </summary>
        private readonly UserRegisteredEventHandler userEventHandler;
        /// <summary>
        /// Evento de integración usado cuando es creado un usuarios
        /// </summary>
        private readonly UserRegisteredEvent userCreatedEvent;

        /// <summary>
        /// Crea una nueva instancia de <see cref="SuscriptionTest"/>
        /// </summary>
        public SuscriptionTest()
        {
            this.userCreatedEvent = new UserRegisteredEvent()
            {
                Id = new Random().Next(1, 1000),
                Age = (ushort)new Random().Next(1, 100),
                Name = nameof(UserRegisteredEvent.Name),
                User = nameof(UserRegisteredEvent.User),
            };

            this.userEventHandler = new UserRegisteredEventHandler();
        }

        /// <summary>
        /// Valida que se inicie correctamente el estado del objeto
        /// </summary>
        [Fact]
        public void Create_InitializeStateObject_GetPropertiesValue()
        {
            // Arrange
            var eventType = this.userCreatedEvent.GetType();
            var eventHandlerType = this.userEventHandler.GetType();

            // Act
            var subscription = Subscription.Create<UserRegisteredEvent, UserRegisteredEventHandler>();

            // Assert
            Assert.Equal(eventType, subscription.EventType);
            Assert.Equal(eventHandlerType, subscription.EventHandlerType);
            Assert.Equal(eventType.Name, subscription.EventName);
        }
    }
}
