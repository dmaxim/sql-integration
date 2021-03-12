
using System.Threading.Tasks;
using Barney.Domain.Events;

namespace Barney.Domain.Repositories
{
    public interface IMessageRepository
    {
        
        Task PublishEvent(IncomeReceived incomeReceived);
    }
}
