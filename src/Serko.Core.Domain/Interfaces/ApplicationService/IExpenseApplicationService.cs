using System.Collections.Generic;
using System.Threading.Tasks;
using Serko.Core.Domain.Entities;

namespace Serko.Core.Domain.Interfaces.ApplicationService
{
    public interface IExpenseApplicationService : IBaseApplicationService
    {
        Expense InvokeImporterEmailData(dynamic request);
        string Add(dynamic request);
        Expense GetById(int id);
        IEnumerable<Expense> GetAll();

    }
}