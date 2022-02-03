using CodeDesignPlus.Event.Bus.Abstractions;
using CodeDesignPlus.Event.Bus.Extensions;
using CodeDesignPlus.Event.Bus.Test.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Test.Helpers
{
    /// <summary>
    /// Type Invalid to check method <see cref="EventBusExtensions.GetEventHandlers{TStartupLogic}"/> 
    /// in the unit test <see cref="EventBusExtensionsTest.GetEventHandlers_NotEmpty_EventsHandlers"/>
    /// </summary>
    public interface IInvalidEventHandler : IEventHandler<UserRegisteredEvent>
    {
    }

    /// <summary>
    /// Type Invalid to check method <see cref="EventBusExtensions.GetEventHandlers{TStartupLogic}"/> 
    /// in the unit test <see cref="EventBusExtensionsTest.GetEventHandlers_NotEmpty_EventsHandlers"/>
    /// </summary>
    public class InvalidEventHandler : IFake, IEventHandler<UserRegisteredEvent>
    {
        /// <summary>
        /// Invocado por el event bus cuando se detecta un evento al que se esta subscrito
        /// </summary>
        /// <param name="data">Información del evento</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica</returns>
        public Task HandleAsync(UserRegisteredEvent data, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Fake Interface to check method <see cref="EventBusExtensions.AddEventsHandlers{TStartupLogic}(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
    /// in unit test <see cref="EventBusExtensionsTest.AddEventHandlers_Services_HandlersQueueAndService"/>
    /// </summary>
    public interface IFake
    {

    }

    /// <summary>
    /// Fake event to check method <see cref="EventBusExtensions.AddEventsHandlers{TStartupLogic}(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
    /// in unit test <see cref="EventBusExtensionsTest.AddEventHandlers_Services_HandlersQueueAndService"/>
    /// </summary>
    public abstract class FakeEvent: EventBase
    {

    }

    /// <summary>
    /// Fake event handler to check method <see cref="EventBusExtensions.AddEventsHandlers{TStartupLogic}(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
    /// in unit test <see cref="EventBusExtensionsTest.AddEventHandlers_Services_HandlersQueueAndService"/>
    /// </summary>
    public class FakeEventHandler: IEventHandler<FakeEvent>
    {
        /// <summary>
        /// Invocado por el event bus cuando se detecta un evento al que se esta subscrito
        /// </summary>
        /// <param name="data">Información del evento</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica</returns>
        public Task HandleAsync(FakeEvent data, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
