using CodeDesignPlus.Event.Bus.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Internal.Queue
{

    /// <summary>
    /// Implementación por defecto para el servicio <see cref="IQueueService{TEventHandler, TEvent}"/>
    /// </summary>
    /// <typeparam name="TEventHandler">Manejador de eventos</typeparam>
    /// <typeparam name="TEvent">Evento de Integración</typeparam>
    public class QueueService<TEventHandler, TEvent> : IQueueService<TEventHandler, TEvent>
        where TEventHandler : IEventHandler<TEvent>
        where TEvent : EventBase
    {
        /// <summary>
        /// Contiene los eventos notificados por el Event Bus
        /// </summary>
        private readonly ConcurrentQueue<TEvent> queueEvent = new ConcurrentQueue<TEvent>();

        /// <summary>
        /// Manejador de eventos
        /// </summary>
        private readonly TEventHandler eventHandler;

        /// <summary>
        /// Crea una nueva instancia de <see cref="QueueService{TEvent}"/>
        /// </summary>
        /// <param name="eventHandler">Event Handler</param>
        public QueueService(TEventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        /// <summary>
        /// Gets the number of elements contained in the System.Collections.Concurrent.ConcurrentQueue`1.
        /// </summary>
        /// <returns>The number of elements contained in the System.Collections.Concurrent.ConcurrentQueue`1.</returns>
        public int Count => this.queueEvent.Count;

        /// <summary>
        /// Determines whether a sequence contains any elements.
        /// </summary>
        /// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
        public bool Any() => this.queueEvent.Any();

        /// <summary>
        /// Agrega un objeto al final de la queue
        /// </summary>
        /// <param name="event">El objeto a agregar al final de la Queu</param>
        /// <exception cref="ArgumentNullException">Se genera cuando <paramref name="event"/> es nulo</exception>
        public void Enqueue(TEvent @event)
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));

            var exist = this.queueEvent.Any(x => x.Equals(@event));

            if (!exist)
                this.queueEvent.Enqueue(@event);
        }

        /// <summary>
        /// Tries to remove and return the object at the beginning of the concurrent queue.
        /// </summary>
        /// <param name="token">Cancellation Token</param>
        /// <returns>Return Task that represents an asynchronous operation.</returns>
        public async Task DequeueAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (this.queueEvent.TryDequeue(out TEvent @event))
                {
                    await this.eventHandler.HandleAsync(@event, token);
                }
            }
        }
    }
}
