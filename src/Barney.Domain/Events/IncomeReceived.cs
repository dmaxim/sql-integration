
using Barney.Domain.Models;

namespace Barney.Domain.Events
{
    public class IncomeReceived : IEvent
    {
        public IncomeReceived(NewIncome newIncome)
        {
            BeforeDeductions = newIncome.BeforeDeductions;
            AfterDeductions = newIncome.AfterDeductions;
        }

        public decimal BeforeDeductions { get; }

        public decimal AfterDeductions { get; }
    }
}
