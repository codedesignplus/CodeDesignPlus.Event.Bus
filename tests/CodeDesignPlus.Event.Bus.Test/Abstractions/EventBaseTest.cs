﻿using CodeDesignPlus.Event.Bus.Test.Helpers;
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
            var eventBus = new UserRegisteredEvent()
            {
                Id = new Random().Next(1, 1000),
                Age = (ushort)new Random().Next(1, 100),
                Name = nameof(UserRegisteredEvent.Name),
                User = nameof(UserRegisteredEvent.User),
            };

            //Assert
            Assert.True(eventBus.Id > 0);
            Assert.NotEmpty(eventBus.IdEvent.ToString());
            Assert.True(eventBus.EventDate > date);
            Assert.Equal(nameof(UserRegisteredEvent.Name), eventBus.Name);
            Assert.Equal(nameof(UserRegisteredEvent.User), eventBus.User);
            Assert.True(eventBus.Age > 0);
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
            var eventBus = new UserRegisteredEvent(guid, date)
            {
                Id = new Random().Next(1, 1000),
                Age = (ushort)new Random().Next(1, 100),
                Name = nameof(UserRegisteredEvent.Name),
                User = nameof(UserRegisteredEvent.User),
            };

            //Assert
            Assert.True(eventBus.Id > 0);
            Assert.Equal(guid.ToString(), eventBus.IdEvent.ToString());
            Assert.Equal(eventBus.EventDate, date);
            Assert.Equal(nameof(UserRegisteredEvent.Name), eventBus.Name);
            Assert.Equal(nameof(UserRegisteredEvent.User), eventBus.User);
            Assert.True(eventBus.Age > 0);
        }

        /// <summary>
        /// Valida que se genere la excepción si la fecha es menor a DateTime.Min
        /// </summary>
        [Fact]
        public void Constructor_Overload_Equals()
        {
            //Arrange
            var idEvent1 = Guid.NewGuid();
            var idEvent2 = idEvent1;

            var event1 = new UserRegisteredEvent(idEvent1, DateTime.Now);

            var event2 = new UserRegisteredEvent(idEvent2, DateTime.Now);

            //Act
            var result = event1.Equals(event2);

            //Assert
            Assert.Equal(event1, event2);
        }

        /// <summary>
        /// Valida que se genere la excepción si la fecha es menor a DateTime.Min
        /// </summary>
        [Fact]
        public void Constructor_Overload_GetHashCode()
        {
            //Arrange
            var idEvent1 = Guid.NewGuid();
            var expected = HashCode.Combine(idEvent1);

            var event1 = new UserRegisteredEvent(idEvent1, DateTime.Now);

            //Act
            var result = event1.GetHashCode();

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
