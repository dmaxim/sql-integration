using Barney.Tests.Integration.Infrastructure.Fixtures;
using Xunit;

namespace Barney.Tests.Integration.Managers
{
    [Collection("Integration Test Collection")]
    public class ExpenseClassificationManagerGetAll
    {
        private readonly IntegrationTestFixture _testFixture;

        public ExpenseClassificationManagerGetAll(IntegrationTestFixture fixture)
        {
            _testFixture = fixture;
        }

        [Fact]   
        public void Returns_A_List_Of_Expense_Classifications()
        {
            
            var x = "stop here";

            var y = "no go";

        }
    }
}
