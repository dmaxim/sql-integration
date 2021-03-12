
using System.Threading.Tasks;
using Barney.Domain.Events;

namespace Barney.Domain.Clients
{
    public interface IMessageApiClient
    {
        Task Publish(IncomeReceived incomeReceived);

    }
}
