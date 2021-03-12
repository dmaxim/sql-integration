using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Barney.Business.Managers.Interfaces;
using Barney.Domain.Events;
using Barney.Domain.Models;
using Barney.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Mx.Library.ExceptionHandling;

namespace Barney.Business.Managers
{
    public class IncomeManager : IIncomeManager
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IIncomeClassificationRepository _incomeClassificationRepository;
        private readonly IExpenseOwnerRepository _expenseOwnerRepository;
        private readonly IMessageRepository _messageRepository;

        public IncomeManager(IIncomeRepository incomeRepository, IEmployerRepository employerRepository, IIncomeClassificationRepository incomeClassificationRepository, 
            IExpenseOwnerRepository expenseOwnerRepository, IMessageRepository messageRepository)
        {
            _incomeRepository = incomeRepository;
            _employerRepository = employerRepository;
            _incomeClassificationRepository = incomeClassificationRepository;
            _expenseOwnerRepository = expenseOwnerRepository;
            _messageRepository = messageRepository;
        }
        public Task<ICollection<Income>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }


        public async Task<ICollection<Income>> GetIndividualIncomeAsync(string ownerUserId)
        {
            return await _incomeRepository.GetAll()
                .Where(income => income.Owner.OwnerUserId == ownerUserId)
                .Include(income => income.Employer)
                .Include(income => income.Classification).ToListAsync().ConfigureAwait(false);
        }


        public async Task<Income> InsertAsync(NewIncome newIncome)
        {
            
            var activity = new Activity("CallToApi")
                .AddBaggage("barneyVersion", "v2.2")
                .AddBaggage("MoreBaggage", "33333")
                .Start();

            
            var expenseOwner = await _expenseOwnerRepository.GetAll()
                .FirstOrDefaultAsync(owner => owner.OwnerUserId == newIncome.ExpenseOwnerUserId).ConfigureAwait(false);

            if (expenseOwner == null)
            {
                throw new MxNotFoundException($"Expense Owner with id {newIncome.ExpenseOwnerUserId} does not exist");
            }

            var income = new Income(newIncome, expenseOwner.ExpenseOwnerId);
            
            _incomeRepository.Insert(income);
            await _incomeRepository.SaveChangesAsync().ConfigureAwait(false);

            await _messageRepository.PublishEvent(new IncomeReceived(newIncome));

            //var source = new ActivitySource("BarneyOT", "3.4");
            //using (var parent = source.StartActivity("PublishMessage", ActivityKind.Server))
            //{
            //    parent?.AddTag("http.method", "POST");
            //    parent?.AddTag("AnotherTag", "What");
            //    await _messageRepository.PublishEvent(new IncomeReceived(newIncome));
            //}


            //activity?.Stop();
            return income;


        }

        public Task<Income> GetAsync(int incomeId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Income income)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Employer>> GetEmployersAsync()
        {
            return await _employerRepository.GetAll().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IList<IncomeClassification>> GetIncomeClassificationsAsync()
        {
            return await _incomeClassificationRepository.GetAll().ToListAsync().ConfigureAwait(false);
        }
    }
}
