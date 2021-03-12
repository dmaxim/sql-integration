using Barney.Domain.Events;

namespace Barney.Business.Events
{
    public class FileSystemEventMessage
    {
        public FileSystemEventMessage(string destination, IEvent eventMessage)
        {

        }

        public string FileName { get; }

        public byte[] Message { get; }
    }
}
