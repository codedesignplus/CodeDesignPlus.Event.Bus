using CodeDesignPlus.Event.Bus.Exceptions;
using CodeDesignPlus.Event.Bus.Test.Helpers;
using System;
using Xunit;

namespace CodeDesignPlus.Event.Bus.Test.Execptions
{

    /// <summary>
    /// Pruebas unitarias a la clase <see cref="EventHandlerAlreadyRegisteredException{TEvent, TEventHandler}"/>
    /// </summary>
    public class EventHandlerAlreadyRegisteredExceptionTest: ExceptionBaseTest
    {
        /// <summary>
        /// Valida el constructor por defecto de la excepción
        /// </summary>
        [Fact]
        public void Constructor_WithoutArguments_Exception()
        {
            // Arrange & Act
            var exception = new EventHandlerAlreadyRegisteredException<UserCreatedEvent, UserEventHandler>();

            // Assert
            Assert.NotEmpty(exception.Message);
            Assert.Null(exception.InnerException);
        }

        /// <summary>
        /// Valida el constructor con el mensaje
        /// </summary>
        [Fact]
        public void Constructor_Message_Exception()
        {
            // Arrange 
            var message = Guid.NewGuid().ToString();

            // Act
            var exception = new EventHandlerAlreadyRegisteredException<UserCreatedEvent, UserEventHandler>(message);

            // Assert
            Assert.Equal(message, exception.Message);
            Assert.Null(exception.InnerException);
        }

        /// <summary>
        /// Valida el constructor con el mensaje y la excepción interna
        /// </summary>
        [Fact]
        public void Constructor_InnerException_Exception()
        {
            // Arrange 
            var message = Guid.NewGuid().ToString();
            var innerException = new InvalidOperationException("The operation is invalid");

            // Act
            var exception = new EventHandlerAlreadyRegisteredException<UserCreatedEvent, UserEventHandler>(message, innerException);

            // Assert
            Assert.Equal(innerException, exception.InnerException);
            Assert.Equal(message, exception.Message);
            Assert.NotNull(exception.InnerException);
        }

        /// <summary>
        /// Valida el constructor con el mensaje y la excepción interna
        /// </summary>
        [Fact]
        public void Constructor_Serealization_Exception()
        {
            // Arrange 
            var message = Guid.NewGuid().ToString();
            var innerException = new InvalidOperationException("The operation is invalid");

            // Act
            var exception = new EventHandlerAlreadyRegisteredException<UserCreatedEvent, UserEventHandler>(message, innerException);
            var bytes = SerializeToBytes(exception);
            var result = DeserializeFromBytes<EventHandlerAlreadyRegisteredException<UserCreatedEvent, UserEventHandler>>(bytes);

            // Assert
            Assert.True(bytes.Length > 0);
            Assert.NotNull(result.Message);
            Assert.NotNull(result.InnerException);
            Assert.Equal(innerException, exception.InnerException);
            Assert.Equal(message, exception.Message);
        }
    }
}
