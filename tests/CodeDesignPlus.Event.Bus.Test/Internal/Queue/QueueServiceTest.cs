using CodeDesignPlus.Event.Bus.Internal.Queue;
using CodeDesignPlus.Event.Bus.Test.Helpers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeDesignPlus.Event.Bus.Test.Internal.Queue
{
    /// <summary>
    /// Pruebas unitarias a la clase <see cref="QueueService{TEventHandler, TEvent}"/>
    /// </summary>
    public class QueueServiceTest
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
        /// Crea una nueva instancia de <see cref="QueueServiceTest"/>
        /// </summary>
        public QueueServiceTest()
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
        /// Valida que se genere la excepción cuando el argumento es nulo
        /// </summary>
        [Fact]
        public void Enqueu_AddEventQueue_ArgumentNullException()
        {
            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => this.queueService.Enqueue(null));

            // Assert
            Assert.NotEmpty(exception.Message);
        }

        /// <summary>
        /// Valida que la queue sea igual cuando el evento ya ha sido agregado
        /// </summary>
        [Fact]
        public void Enqueu_EventAlreadyExist_TailRemainsTheSame()
        {
            // Arrange
            this.queueService.Enqueue(this.userCreatedEvent);

            // Act
            this.queueService.Enqueue(this.userCreatedEvent);

            // Assert
            Assert.Equal(1, this.queueService.Count);
        }

        /// <summary>
        /// Valida que se registre el evento en la Queue
        /// </summary>
        [Fact]
        public void Enqueue_Add_QueueNotEmpty()
        {
            // Act
            this.queueService.Enqueue(this.userCreatedEvent);

            // Assert
            Assert.True(this.queueService.Any());
        }

        /// <summary>
        /// Valida que se obtena el evento
        /// </summary>
        [Fact]
        public void DequeueAsync_Get_QueueEmpty()
        {
            // Arrange
            this.queueService.Enqueue(this.userCreatedEvent);

            // Act
            Task.Run(() => this.queueService.DequeueAsync(CancellationToken.None));

            Thread.Sleep(TimeSpan.FromSeconds(15));

            // Assert
            Assert.NotNull(UserEventHandler.Events.FirstOrDefault(x => x.Value == this.userCreatedEvent).Value);
            Assert.False(this.queueService.Any());
        }
    }
}
