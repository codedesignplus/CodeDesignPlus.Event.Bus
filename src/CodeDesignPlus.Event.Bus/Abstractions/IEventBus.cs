using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Abstractions
{
    /// <summary>
    /// Interface generica para implementación de bus de eventos
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Metodo encargado de publicar un evento de integración
        /// </summary>
        /// <param name="event">Información del Evento a publicar</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica</returns>
        Task PublishAsync(EventBase @event, CancellationToken token);
        /// <summary>
        /// Metodo encargado de publicar un evento de integración
        /// </summary>
        /// <param name="event">Información del Evento a publicar</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica, la información determinada por la implementación de la interfaz</returns>
        Task<TResult> PublishAsync<TResult>(EventBase @event, CancellationToken token);
        /// <summary>
        /// Metodo encargado de escuchar un evento de integración
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a escuchar</typeparam>
        /// <typeparam name="TEventHandler">Manejador de eventos de integración (Callback)</typeparam>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica</returns>
        Task SubscribeAsync<TEvent, TEventHandler>() 
            where TEvent : EventBase 
            where TEventHandler : IEventHandler<TEvent>;

        /// <summary>
        /// Metodo encargado de cancelar la suscripción de un evento
        /// </summary>
        /// <typeparam name="TEvent">Evento de integración a escuchar</typeparam>
        /// <typeparam name="TEventHandler">Manejador de eventos de integración (Callback)</typeparam>
        void Unsubscribe<TEvent, TEventHandler>() 
            where TEvent : EventBase 
            where TEventHandler : IEventHandler<TEvent>;
    }
}
