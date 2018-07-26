using System.Threading.Tasks;
using Serko.Core.Domain.Entities;

namespace Serko.Core.Domain.Interfaces.Service
{
    public interface IEmployeeService
    {
        Task<Employee> AuthenticationByUsernameAsync(Employee employee);

        Task<Employee> AuthenticationByBarcodeAsync(Employee employee);
    }
}