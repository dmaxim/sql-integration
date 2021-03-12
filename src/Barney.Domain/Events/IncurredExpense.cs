using System;


namespace Barney.Domain.Events
{
    public class IncurredExpense : IEvent
    {
        public string ExpenseOwner { get; set; }

        public string Classification { get; set; }

        public string Description { get; set; }

        public DateTimeOffset IncurredDate { get; set;  }

        public decimal Amount { get; set; }
    }
}
