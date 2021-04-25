using CodeDesignPlus.Event.Bus.Test.Helpers;
using System;
using Xunit;

namespace CodeDesignPlus.Event.Bus.Test.Abstractions
{
    /// <summary>
    /// Pruebas unitarias a la clase <see cref="Bus.Abstractions.EventBase"/>
    /// </summary>
    public class EventBaseTest
    {
        /// <summary>
        /// Valida que se genere automaticamente el identificador y la fecha del evento
        /// </summary>
        [Fact]
        public void Constructor_Default_GetValues()
        {
            //Arrange
            var date = DateTime.Now;

            //Act
            var eventBus = new UserCreatedEvent()
            {
                Id = new Random().Next(1, 1000),
                Age = (ushort)new Random().Next(1, 100),
                Name = nameof(UserCreatedEvent.Name),
                User = nameof(UserCreatedEvent.User),
            };

            //Assert
            Assert.True(eventBus.Id > 0);
            Assert.NotEmpty(eventBus.IdEvent.ToString());
            Assert.True(eventBus.EventDate > date);
            Assert.Equal(nameof(UserCreatedEvent.Name), eventBus.Name);
            Assert.Equal(nameof(UserCreatedEvent.User), eventBus.User);
        }

        /// <summary>
        /// Valida que se asigne el identificador y la fecha del evento
        /// </summary>
        [Fact]
        public void Constructor_Overload_GetValues()
        {
            //Arrange
            var date = DateTime.Now;
            var guid = Guid.NewGuid();

            //Act
            var eventBus = new UserCreatedEvent(guid, date)
            {
                Id = new Random().Next(1, 1000),
                Age = (ushort)new Random().Next(1, 100),
                Name = nameof(UserCreatedEvent.Name),
                User = nameof(UserCreatedEvent.User),
            };

            //Assert
            Assert.True(eventBus.Id > 0);
            Assert.NotEmpty(eventBus.IdEvent.ToString());
            Assert.Equal(eventBus.EventDate, date);
            Assert.Equal(nameof(UserCreatedEvent.Name), eventBus.Name);
            Assert.Equal(nameof(UserCreatedEvent.User), eventBus.User);
        }
    }
}
