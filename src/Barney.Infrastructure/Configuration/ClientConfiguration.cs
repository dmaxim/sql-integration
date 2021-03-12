

using System;

namespace Barney.Infrastructure.Configuration
{
    public class ClientConfiguration
    {

        public string MessageService { get; set; }

        public void ThrowIfInvalid()
        {
            if (string.IsNullOrWhiteSpace(MessageService))
            {
                throw new ArgumentNullException(nameof(MessageService));
            }
        }
    }
}
