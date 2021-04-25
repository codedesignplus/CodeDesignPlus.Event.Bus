using CodeDesignPlus.Event.Bus.Abstractions;
using CodeDesignPlus.Event.Bus.Exceptions;
using CodeDesignPlus.Event.Bus.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CodeDesignPlus.Event.Bus.Without.EventBusService.Test.Extensions
{
    /// <summary>
    ///  Pruebas unitarias a la clase <see cref="EventBusExtensions"/>
    /// </summary>
    public class EventBusExtensionsTest
    {
        /// <summary>
        /// Valida que se genere la excepción cuando no se encuentra un servicio que implemente la interfaz <see cref="IEventBus"/>
        /// </summary>
        [Fact]
        public void AddEventBus_EventNotImplemented_EventNotImplementedException()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act & Assert
            Assert.Throws<EventNotImplementedException>(() => services.AddEventBus());
        }
    }
}
