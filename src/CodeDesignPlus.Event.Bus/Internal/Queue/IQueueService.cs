using CodeDesignPlus.Event.Bus.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Internal.Queue
{
    /// <summary>
    /// Servicio que administra los eventos notificados por el event bus
    /// </summary>
    /// <typeparam name="TEvent">Evento de Integración</typeparam>
    /// <typeparam name="TEventHandler">Manejador de eventos</typeparam>
    public interface IQueueService<TEventHandler, in TEvent>
        where TEventHandler : IEventHandler<TEvent>
        where TEvent : EventBase
    {
        /// <summary>
        /// Agrega un objeto al final de la queue
        /// </summary>
        /// <param name="event">El objeto a agregar al final de la Queu</param>
        /// <exception cref="ArgumentNullException">Se genera cuando <paramref name="event"/> es nulo</exception>
        void Enqueue(TEvent @event);
        /// <summary>
        /// Tries to remove and return the object at the beginning of the concurrent queue.
        /// </summary>
        /// <param name="token">Cancellation Token</param>
        /// <returns>Return Task that represents an asynchronous operation.</returns>
        Task DequeueAsync(CancellationToken token);
    }
}
