
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barney.Business.Managers
{
    public class ExpenseClassificationManager : IExpenseClassificationManager
    {
        private readonly IExpenseClassificationRepository _expenseClassificationRepository;

        public ExpenseClassificationManager(IExpenseClassificationRepository expenseClassificationRepository)
        {
            _expenseClassificationRepository = expenseClassificationRepository;
        }
        public async Task<ICollection<ExpenseClassification>> GetAllAsync()
        {
            return await _expenseClassificationRepository.GetAll().ToListAsync(); ;
        }
    }
}
