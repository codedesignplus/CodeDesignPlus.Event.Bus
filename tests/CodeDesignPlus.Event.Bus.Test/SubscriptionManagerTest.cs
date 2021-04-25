using CodeDesignPlus.Event.Bus.Exceptions;
using CodeDesignPlus.Event.Bus.Test.Helpers;
using Xunit;

namespace CodeDesignPlus.Event.Bus.Test
{
    /// <summary>
    /// Pruebas unitarias a la clase <see cref="SubscriptionManager"/>
    /// </summary>
    public class SubscriptionManagerTest
    {
        /// <summary>
        /// Valida que retorne false cuando no se tienen events handlers registrados
        /// </summary>
        [Fact]
        public void Any_Empty_False()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            // Act & Assert
            Assert.False(subscription.Any());
        }


        /// <summary>
        /// Valida que retorne true cuando no se tienen events handlers registrados
        /// </summary>
        [Fact]
        public void Any_Empty_True()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Act & Assert
            Assert.True(subscription.Any());
        }

        /// <summary>
        /// Valida que retorne el nombre del evento
        /// </summary>
        [Fact]
        public void GetEventKey_NameEvent_EventKey()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            // Act
            var eventName = subscription.GetEventKey<UserCreatedEvent>();

            // Assert
            Assert.Equal(typeof(UserCreatedEvent).Name, eventName);
        }

        /// <summary>
        /// Valida que se registre el evento cuando no tiene una subscription asociada
        /// </summary>
        [Fact]
        public void AddSubscription_EventHasNotSubscription_HandlerNotEmpty()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            // Act
            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Assert
            var subscriptionEvent = subscription.FindSubscription<UserCreatedEvent, UserEventHandler>();
            Assert.NotNull(subscriptionEvent);
        }


        /// <summary>
        /// Valida que se genere la excepción cuando se quiere asociar otra suscripción al mismo evento
        /// </summary>
        [Fact]
        public void AddSubscription_EventHasSubscription_EventHandlerAlreadyRegisteredException()
        {
            // Arrange
            var eventType = typeof(UserCreatedEvent);
            var eventHandlerType = typeof(UserEventHandler);
            var subscription = new SubscriptionManager();
            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Act & Assert
            var exception = Assert.Throws<EventHandlerAlreadyRegisteredException<UserCreatedEvent, UserEventHandler>>(() => subscription.AddSubscription<UserCreatedEvent, UserEventHandler>());

            // Assert
            Assert.NotEmpty(exception.Message);
            Assert.Equal(eventType, exception.EventType);
            Assert.Equal(eventHandlerType, exception.EventHandlerType);
        }

        /// <summary>
        /// Valida que no se remueva la suscripción debido a que el evento no esta registrado
        /// </summary>
        [Fact]
        public void RemoveSubscription_EventNotRegistered_NotRemove()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            // Act & Assert
            var exception = Assert.Throws<EventIsNotRegisteredException>(() => subscription.RemoveSubscription<UserCreatedEvent, UserEventHandler>());

            // Assert
            Assert.NotEmpty(exception.Message);
            Assert.False(subscription.Any());
        }

        /// <summary>
        /// Valida que se remueva la suscripción cuando el evento esta registrado
        /// </summary>
        [Fact]
        public void RemoveSubscription_EventRegistered_NotRemove()
        {
            // Arrange
            var subscription = new SubscriptionManager();
            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Act
            subscription.RemoveSubscription<UserCreatedEvent, UserEventHandler>();

            // Assert
            Assert.False(subscription.Any());
        }

        /// <summary>
        /// Valida que el evento no tenga suscripciones
        /// </summary>
        [Fact]
        public void HasSubscriptionsForEvent_EventNotRegistered_False()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            // Act
            var hasSubscription = subscription.HasSubscriptionsForEvent<UserCreatedEvent>();

            // Assert
            Assert.False(hasSubscription);
        }

        /// <summary>
        /// Valida que el evento tenga suscripciones
        /// </summary>
        [Fact]
        public void HasSubscriptionsForEvent_EventRegistered_True()
        {
            // Arrange
            var subscription = new SubscriptionManager();
            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Act
            var hasSubscription = subscription.HasSubscriptionsForEvent<UserCreatedEvent>();

            // Assert
            Assert.True(hasSubscription);
        }

        /// <summary>
        /// Valida que se genere la excepción cuando el evento no se encuentra registrado
        /// </summary>
        [Fact]
        public void GetHandlers_EventNotRegistered_EventIsNotRegisteredException()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            // Act & Assert
            var exception = Assert.Throws<EventIsNotRegisteredException>(() => subscription.GetHandlers<UserCreatedEvent>());

            // Assert
            Assert.NotEmpty(exception.Message);
        }

        /// <summary>
        /// Valida que retorne los event handlers asociados al evento registrado
        /// </summary>
        [Fact]
        public void GetHandlers_EventRegistered_EventHandlers()
        {
            // Arrange
            var subscription = new SubscriptionManager();
            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Act
            var handlers = subscription.GetHandlers<UserCreatedEvent>();

            // Assert
            Assert.Contains(handlers, handler => handler.EventHandlerType == typeof(UserEventHandler));
        }

        /// <summary>
        /// Valida que se genere la excepción cuando el evento no tiene una suscripción asociada
        /// </summary>
        [Fact]
        public void FindSubscription_EventHasNotSubscription_EventIsNotRegisteredException()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            // Act
            var exception = Assert.Throws<EventIsNotRegisteredException>(() => subscription.FindSubscription<UserCreatedEvent, UserEventHandler>());

            // Assert
            Assert.NotEmpty(exception.Message);
        }

        /// <summary>
        /// Valida que retorne la suscripción asociada al evento
        /// </summary>
        [Fact]
        public void FindSubscription_EventHasSubscription_Subscription()
        {
            // Arrange
            var subscription = new SubscriptionManager();
            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Act
            var subscriptionEvent = subscription.FindSubscription<UserCreatedEvent, UserEventHandler>();

            // Assert
            Assert.NotNull(subscriptionEvent);
            Assert.Equal(typeof(UserCreatedEvent), subscriptionEvent.EventType);
            Assert.Equal(typeof(UserEventHandler), subscriptionEvent.EventHandlerType);
            Assert.Equal(typeof(UserCreatedEvent).Name, subscriptionEvent.EventName);
        }

        /// <summary>
        /// Valida que se genere la excepción cuando el evento no tiene una suscripción asociada
        /// </summary>
        [Fact]
        public void FindSubscriptions_EventHasNotSubscription_EventIsNotRegisteredException()
        {
            // Arrange
            var subscription = new SubscriptionManager();

            // Act
            var exception = Assert.Throws<EventIsNotRegisteredException>(() => subscription.FindSubscriptions<UserCreatedEvent>());

            // Assert
            Assert.NotEmpty(exception.Message);
        }

        /// <summary>
        /// Valida que retorne las suscripciones asociadas al evento
        /// </summary>
        [Fact]
        public void FindSubscriptions_EventHasSubscription_Subscriptions()
        {
            // Arrange
            var subscription = new SubscriptionManager();
            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Act
            var subscriptionsEvents = subscription.FindSubscriptions<UserCreatedEvent>();

            // Assert
            Assert.NotEmpty(subscriptionsEvents);
            Assert.Contains(subscriptionsEvents, x =>
                x.EventType == typeof(UserCreatedEvent) &&
                x.EventHandlerType == typeof(UserEventHandler) &&
                x.EventName == typeof(UserCreatedEvent).Name
            );
        }

        /// <summary>
        /// Valida que no queden suscripciones registradas
        /// </summary>
        public void Clear_Subscriptions_Empty()
        {
            // Arrange
            var subscription = new SubscriptionManager();
            subscription.AddSubscription<UserCreatedEvent, UserEventHandler>();

            // Act
            subscription.Clear();

            // Assert
            Assert.False(subscription.Any());
        }
    }
}
