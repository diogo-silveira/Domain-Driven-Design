using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Serko.Core.Domain.Entities;
using Serko.Core.Domain.Interfaces.Repository;
using Serko.Core.Infrastructure.Data.Context;

namespace Serko.Core.Infrastructure.Data.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly SerkoCoreDataContext _serkoCoreDataContext;

        public ExpenseRepository(SerkoCoreDataContext serkoCoreDataContext)
            => _serkoCoreDataContext = serkoCoreDataContext;

        public Expense Add(Expense expense)
        {
            var result =  _serkoCoreDataContext.Expense.Add(expense).Entity;
            _serkoCoreDataContext.SaveChanges();
            return result;
        }

        public Expense GetById(int id)
        {
            return _serkoCoreDataContext.Expense.Find(id);
        }

        public IEnumerable<Expense> GetAll()
        {
            return _serkoCoreDataContext.Expense.ToList();
        }
    }
}