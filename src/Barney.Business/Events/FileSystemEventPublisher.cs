
using Barney.Domain.Events;
using System.Threading.Tasks;

namespace Barney.Business.Events
{
    public class FileSystemEventPublisher : IEventPublisher
    {
        private readonly string _destination;
        public FileSystemEventPublisher(string destination)
        {
            _destination = destination;
        }

        public Task Publish(IEvent eventMessage)
        {
            //  Write event json to the file system
            throw new System.NotImplementedException();
        }
    }
}
