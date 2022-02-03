using CodeDesignPlus.Event.Bus.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Test.Helpers
{
    /// <summary>
    /// Event Handler process to type <see cref="UserRegisteredEvent"/>
    /// </summary>
    public class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
    {
        /// <summary>
        /// Store events <see cref="Bus.Internal.Queue.QueueService{TEventHandler, TEvent}"/>
        /// </summary>
        public ConcurrentDictionary<Guid, UserRegisteredEvent> Events = new ConcurrentDictionary<Guid, UserRegisteredEvent>();

        /// <summary>
        /// Invoked by the event bus when an event to which it is subscribed is detected
        /// </summary>
        /// <param name="data">Event Info</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task represents an asynchronous operation.</returns>
        public Task HandleAsync(UserRegisteredEvent data, CancellationToken token)
        {
            Events.TryAdd(data.IdEvent, data);

            return Task.CompletedTask;
        }
    }
}
