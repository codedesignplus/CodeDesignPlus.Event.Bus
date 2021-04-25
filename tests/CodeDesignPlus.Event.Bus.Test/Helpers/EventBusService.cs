using CodeDesignPlus.Event.Bus.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Test.Helpers
{
    /// <summary>
    /// Implementación del Bus de eventos
    /// </summary>
    public class EventBusService : IEventBus
    {
        /// <summary>
        /// Subscription Manager
        /// </summary>
        public ISubscriptionManager Subscription { get; set; }

        /// <summary>
        /// Crea una nueva instancia de <see cref="EventBusService"/>
        /// </summary>
        public EventBusService(ISubscriptionManager subscriptionManager)
        {
            this.Subscription = subscriptionManager;
        }

        /// <summary>
        /// Metodo encargado de publicar un evento de integración
        /// </summary>
        /// <param name="event">Información del Evento a publicar</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica</returns>
        public Task PublishAsync(EventBase @event, CancellationToken token)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Metodo encargado de publicar un evento de integración
        /// </summary>
        /// <param name="event">Información del Evento a publicar</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica, la información determinada por la implementación de la interfaz</returns>
        public Task<TResult> PublishAsync<TResult>(EventBase @event, CancellationToken token)
        {
            return default;
        }

        /// <summary>
        /// Metodo encargado de escuchar un evento de integración
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a escuchar</typeparam>
        /// <typeparam name="TEventHandler">Manejador de eventos de integración (Callback)</typeparam>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica</returns>
        public Task SubscribeAsync<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>
        {
            this.Subscription.AddSubscription<TEvent, TEventHandler>();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Metodo encargado de cancelar la suscripción de un evento
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a escuchar</typeparam>
        /// <typeparam name="TEventHandler">Manejador de eventos de integración (Callback)</typeparam>
        public void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : EventBase
            where TEventHandler : IEventHandler<TEvent>
        {

        }
    }
}
