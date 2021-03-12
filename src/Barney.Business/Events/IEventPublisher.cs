
using System.Threading.Tasks;
using Barney.Domain.Events;

namespace Barney.Business.Events
{
    public interface IEventPublisher
    {
        Task Publish(IEvent eventMessage);
    }
}
