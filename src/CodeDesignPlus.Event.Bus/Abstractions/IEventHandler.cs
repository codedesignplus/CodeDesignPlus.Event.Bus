using System.Threading;
using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Abstractions
{
    /// <summary>
    /// Interfaz base para implementar un manejador de eventos a partir de un evento definido
    /// </summary>
    /// <typeparam name="TEvent">Evento de Integración</typeparam>
    public interface IEventHandler<in TEvent> 
        where TEvent : EventBase
    {
        /// <summary>
        /// Invocado por el event bus cuando se detecta un evento al que se esta subscrito
        /// </summary>
        /// <param name="data">Información del evento</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>System.Threading.Tasks.Task que representa la operación asincrónica</returns>
        Task HandleAsync(TEvent data, CancellationToken token);
    }
}
