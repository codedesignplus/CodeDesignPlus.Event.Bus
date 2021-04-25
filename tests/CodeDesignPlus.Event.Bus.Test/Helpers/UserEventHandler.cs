using CodeDesignPlus.Event.Bus.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Test.Helpers
{
    /// <summary>
    /// Event Handler que procesa los eventos de tipo <see cref="UserCreatedEvent"/>
    /// </summary>
    public class UserEventHandler : IEventHandler<UserCreatedEvent>
    {
        /// <summary>
        /// Store de eventos enviados por el servicio <see cref="Bus.Internal.Queue.QueueService{TEventHandler, TEvent}"/>
        /// </summary>
        public static ConcurrentDictionary<Guid, UserCreatedEvent> Events = new ConcurrentDictionary<Guid, UserCreatedEvent>();

        /// <summary>
        /// Invocado por el event bus cuando se detecta un evento al que se esta subscrito
        /// </summary>
        /// <param name="data">Información del evento</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica</returns>
        public Task HandleAsync(UserCreatedEvent data, CancellationToken token)
        {
            Events.TryAdd(data.IdEvent, data);

            return Task.CompletedTask;
        }
    }
}
