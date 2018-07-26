using System.Collections.Generic;
using System.Threading.Tasks;
using Serko.Core.Domain.DTO.Request;
using Serko.Core.Domain.Entities;

namespace Serko.Core.Domain.Interfaces.Service
{
    public interface IExpenseService
    {
        Expense InvokeImporterEmailData(ExpenseEmailRequest request);

        Expense Add(Expense request);
        Expense GetById(int id);
        IEnumerable<Expense> GetAll();
    }
}