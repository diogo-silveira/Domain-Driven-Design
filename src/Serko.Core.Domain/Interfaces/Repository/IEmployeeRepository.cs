using System.Threading.Tasks;
using Serko.Core.Domain.Entities;

namespace Serko.Core.Domain.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> AuthenticationByUsernameAsync(Employee employee);

        Task<Employee> AuthenticationByBarcodeAsync(Employee employee);
    }
}