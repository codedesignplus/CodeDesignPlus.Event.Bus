using System.Threading.Tasks;

namespace CodeDesignPlus.Event.Bus.Abstractions
{
    public interface IValidateEvent
    {
        Task<bool> ValidateEvent(EventBase @event);
    }
}
