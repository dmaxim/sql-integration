

using Xunit;

namespace Barney.Tests.Integration.Infrastructure.Fixtures
{
    [CollectionDefinition("Integration Test Collection")]
    public class IntegrationTestCollection : ICollectionFixture<IntegrationTestFixture>
    {
    }
}
