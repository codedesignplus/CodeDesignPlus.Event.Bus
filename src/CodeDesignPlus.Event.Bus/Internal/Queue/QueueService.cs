﻿using CodeDesignPlus.Event.Bus.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Internal.Queue
{

    /// <summary>
    /// Implementación por defecto para el servicio <see cref="IQueueService{TEvent}"/>
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
        public QueueService(TEventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        /// <summary>
        /// Agrega un objeto al final de la queue
        /// </summary>
        /// <param name="event">El objeto a agregar al final de la Queu</param>
        /// <exception cref="ArgumentNullException">Se genera cuando <paramref name="event"/> es nulo</exception>
        public void Enqueue(TEvent @event)
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));

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
