using CodeDesignPlus.Event.Bus.Internal.Queue;
using CodeDesignPlus.Event.Bus.Test.Helpers;
using System;
using System.Linq;
using System.Threading;
using Xunit;
using ES = CodeDesignPlus.Event.Bus.Internal.EventBusBackgroundService;

namespace CodeDesignPlus.Event.Bus.Test.Internal.EventBusBackgroundService
{
    /// <summary>
    /// Pruebas unitarias a la clase <see cref="QueueService{TEventHandler, TEvent}"/>
    /// </summary>
    public class EventBusBackgroundServiceTest
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
        /// ervicio que administra los eventos notificados por el event bus
        /// </summary>
        private readonly QueueService<UserRegisteredEventHandler, UserRegisteredEvent> queueService;

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventBusBackgroundServiceTest"/>
        /// </summary>
        public EventBusBackgroundServiceTest()
        {
            this.userCreatedEvent = new UserRegisteredEvent()
            {
                Id = new Random().Next(1, 1000),
                Age = (ushort)new Random().Next(1, 100),
                Name = nameof(UserRegisteredEvent.Name),
                User = nameof(UserRegisteredEvent.User),
            };

            this.userEventHandler = new UserRegisteredEventHandler();

            this.queueService = new QueueService<UserRegisteredEventHandler, UserRegisteredEvent>(this.userEventHandler);
        }

        /// <summary>
        /// Valida que se obtena el evento
        /// </summary>
        [Fact]
        public void ExecuteAsync_DequeueEvents_QueueEmpty()
        {
            // Arrange
            this.queueService.Enqueue(this.userCreatedEvent);
            var backgroundService = new ES.EventBusBackgroundService<UserRegisteredEventHandler, UserRegisteredEvent>(this.queueService);

            // Act
            backgroundService.StartAsync(CancellationToken.None).ConfigureAwait(false);

            Thread.Sleep(TimeSpan.FromSeconds(15));

            // Assert
            Assert.NotNull(this.userEventHandler.Events.FirstOrDefault(x => x.Value == this.userCreatedEvent).Value);
            Assert.False(this.queueService.Any());
        }
    }
}
