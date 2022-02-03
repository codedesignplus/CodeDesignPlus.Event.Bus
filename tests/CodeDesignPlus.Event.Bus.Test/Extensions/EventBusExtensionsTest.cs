using CodeDesignPlus.Event.Bus.Abstractions;
using CodeDesignPlus.Event.Bus.Extensions;
using CodeDesignPlus.Event.Bus.Internal.EventBusBackgroundService;
using CodeDesignPlus.Event.Bus.Internal.Queue;
using CodeDesignPlus.Event.Bus.Test.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace CodeDesignPlus.Event.Bus.Test.Extensions
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
        public void AddEventBus_RegisterServices_ServicesBase()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act 
            services.AddEventBus();

            // Assert
            var subscriptionManager = services.FirstOrDefault(x => typeof(ISubscriptionManager).IsAssignableFrom(x.ImplementationType));
            var eventBus = services.FirstOrDefault(x => typeof(IEventBus).IsAssignableFrom(x.ImplementationType));

            Assert.Equal(typeof(SubscriptionManager), subscriptionManager.ImplementationType);
            Assert.Equal(ServiceLifetime.Singleton, subscriptionManager.Lifetime);

            Assert.Equal(typeof(EventBusService), eventBus.ImplementationType);
            Assert.Equal(ServiceLifetime.Singleton, eventBus.Lifetime);
        }

        /// <summary>
        /// Valida que se registre los event handler, ques and host service
        /// </summary>
        [Fact]
        public void AddEventHandlers_Services_HandlersQueueAndService()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddEventBus();

            // Act
            services.AddEventsHandlers<Startup>();

            // Assert
            var handler = services.FirstOrDefault(x =>
                x.ImplementationType.IsAssignableGenericFrom(typeof(IEventHandler<>)) &&
                x.ImplementationType == typeof(UserRegisteredEventHandler)
            );

            var queue = services.FirstOrDefault(x =>
                x.ImplementationType.IsAssignableGenericFrom(typeof(IQueueService<,>)) &&
                x.ImplementationType == typeof(QueueService<UserRegisteredEventHandler, UserRegisteredEvent>)
            );

            var hostService = services.FirstOrDefault(x =>
                x.ImplementationType.IsAssignableGenericFrom(typeof(IEventBusBackgroundService<,>)) &&
                x.ImplementationType == typeof(EventBusBackgroundService<UserRegisteredEventHandler, UserRegisteredEvent>)
            );

            Assert.Equal(typeof(UserRegisteredEventHandler), handler.ImplementationType);
            Assert.Equal(ServiceLifetime.Transient, handler.Lifetime);

            Assert.Equal(typeof(QueueService<UserRegisteredEventHandler, UserRegisteredEvent>), queue.ImplementationType);
            Assert.Equal(ServiceLifetime.Singleton, queue.Lifetime);

            Assert.Equal(typeof(EventBusBackgroundService<UserRegisteredEventHandler, UserRegisteredEvent>), hostService.ImplementationType);
            Assert.Equal(ServiceLifetime.Transient, hostService.Lifetime);
        }

        /// <summary>
        /// Valida que se registre los event handler, ques and host service
        /// </summary>
        [Fact]
        public void SubscribeEventsHandlers_EventsHandlers_Subscriptions()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddEventBus();
            services.AddEventsHandlers<Startup>();

            var serviceProvider = services.BuildServiceProvider();
            var subscriptionManager = serviceProvider.GetService<ISubscriptionManager>();

            // Act
            serviceProvider.SubscribeEventsHandlers<Startup>();

            // Assert
            var subscription = subscriptionManager.FindSubscription<UserRegisteredEvent, UserRegisteredEventHandler>();

            Assert.NotNull(subscription);
            Assert.Equal(typeof(UserRegisteredEvent), subscription.EventType);
            Assert.Equal(typeof(UserRegisteredEventHandler), subscription.EventHandlerType);
        }

        /// <summary>
        /// Valida que retorne true si la clase implementa una determinada interfaz generica
        /// </summary>
        [Fact]
        public void IsAssignableGenericFrom_ClassImplementInterface_True()
        {
            // Arrange
            var eventHandler = new UserRegisteredEventHandler();

            // Act
            var success = eventHandler.GetType().IsAssignableGenericFrom(typeof(IEventHandler<>));

            // Assert
            Assert.True(success);
        }

        /// <summary>
        /// Valida que retorne false si la clase no implementa una determinada interfaz generica
        /// </summary>
        [Fact]
        public void IsAssignableGenericFrom_ClassNotImplementInterface_False()
        {
            // Arrange
            var eventHandler = new UserRegisteredEventHandler();

            // Act
            var success = eventHandler.GetType().IsAssignableGenericFrom(typeof(IQueueService<,>));

            // Assert
            Assert.False(success);
        }

        /// <summary>
        /// Valida que retorne los event handler del assembly
        /// </summary>
        [Fact]
        public void GetEventHandlers_NotEmpty_EventsHandlers()
        {
            // Arrange & Act
            var eventHandlers = EventBusExtensions.GetEventHandlers<Startup>();

            // Assert
            Assert.NotEmpty(eventHandlers);
        }
    }
}
