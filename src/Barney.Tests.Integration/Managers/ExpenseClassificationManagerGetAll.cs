using Barney.Business.Managers.Interfaces;
using Barney.Tests.Integration.Infrastructure.Fixtures;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task Returns_A_List_Of_Expense_Classifications()
        {

            var expenseClassificationManager = _testFixture.Resolve<IExpenseClassificationManager>();

            var expenseClassifications = await expenseClassificationManager.GetAllAsync();

            Assert.True(expenseClassifications.Any());

        }
    }
}
