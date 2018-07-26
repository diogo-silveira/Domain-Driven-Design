using System.Collections.Generic;
using System.Threading.Tasks;
using Serko.Core.Domain.Entities;

namespace Serko.Core.Domain.Interfaces.Repository
{
    public interface IExpenseRepository
    {

        Expense Add(Expense request);
        Expense GetById(int id);
        IEnumerable<Expense> GetAll();
    }
}