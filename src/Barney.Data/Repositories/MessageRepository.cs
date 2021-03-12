using System.Threading.Tasks;
using Barney.Domain.Clients;
using Barney.Domain.Events;
using Barney.Domain.Repositories;

namespace Barney.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMessageApiClient _messageApiClient;

        public MessageRepository(IMessageApiClient messageApiClient)
        {
            _messageApiClient = messageApiClient;
        }

        public async Task PublishEvent(IncomeReceived incomeReceived)
        {
            await _messageApiClient.Publish(incomeReceived).ConfigureAwait(false);
        }
    }
}
