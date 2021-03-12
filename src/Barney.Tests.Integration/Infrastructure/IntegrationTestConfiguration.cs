

namespace Barney.Tests.Integration.Infrastructure
{
    public class IntegrationTestConfiguration
    {
        public bool UseDockerDependencies { get; set; }

        public bool PullDockerImages { get; set; }

        public string EntityContext { get; set;  }
    }
}
