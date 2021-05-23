using CodeDesignPlus.Event.Bus.Abstractions;
using CodeDesignPlus.Event.Bus.Internal.Queue;

namespace CodeDesignPlus.Event.Bus.Internal.EventBusBackgroundService
{
    /// <summary>
    /// Procesa las queue que se registraron al iniciar la aplicación
    /// </summary>
    /// <typeparam name="TEventHandler">Manejador de eventos</typeparam>
    /// <typeparam name="TEvent">Evento de Integración</typeparam>
    public interface IEventBusBackgroundService<TEventHandler, TEvent>
        where TEventHandler : IEventHandler<TEvent>
        where TEvent : EventBase
    {
    }
}