
using Barney.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barney.Business.Managers.Interfaces
{
    public interface IExpenseClassificationManager
    {
        Task<ICollection<ExpenseClassification>> GetAllAsync();
    }
}
