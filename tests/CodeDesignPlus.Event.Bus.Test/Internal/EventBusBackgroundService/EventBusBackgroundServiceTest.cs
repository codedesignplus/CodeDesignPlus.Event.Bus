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
        /// Event Handler que procesa los eventos de tipo <see cref="UserCreatedEvent"/>
        /// </summary>
        private readonly UserEventHandler userEventHandler;
        /// <summary>
        /// Evento de integración usado cuando es creado un usuarios
        /// </summary>
        private readonly UserCreatedEvent userCreatedEvent;
        /// <summary>
        /// ervicio que administra los eventos notificados por el event bus
        /// </summary>
        private readonly QueueService<UserEventHandler, UserCreatedEvent> queueService;

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventBusBackgroundServiceTest"/>
        /// </summary>
        public EventBusBackgroundServiceTest()
        {
            this.userCreatedEvent = new UserCreatedEvent()
            {
                Id = new Random().Next(1, 1000),
                Age = (ushort)new Random().Next(1, 100),
                Name = nameof(UserCreatedEvent.Name),
                User = nameof(UserCreatedEvent.User),
            };

            this.userEventHandler = new UserEventHandler();

            this.queueService = new QueueService<UserEventHandler, UserCreatedEvent>(this.userEventHandler);
        }

        /// <summary>
        /// Valida que se obtena el evento
        /// </summary>
        [Fact]
        public void ExecuteAsync_DequeueEvents_QueueEmpty()
        {
            // Arrange
            this.queueService.Enqueue(this.userCreatedEvent);
            var backgroundService = new ES.EventBusBackgroundService<QueueService<UserEventHandler, UserCreatedEvent>, UserEventHandler, UserCreatedEvent>(this.queueService);

            // Act
            backgroundService.StartAsync(CancellationToken.None).ConfigureAwait(false);

            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Assert
            Assert.NotNull(UserEventHandler.Events.FirstOrDefault(x => x.Value == this.userCreatedEvent).Value);
            Assert.False(this.queueService.Any());
        }
    }
}
