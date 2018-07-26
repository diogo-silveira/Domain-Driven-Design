using System.Threading.Tasks;
using Serko.Core.Domain.Entities;
using Serko.Core.Domain.Interfaces.Repository;
using Serko.Core.Domain.Interfaces.Service;

namespace Serko.Core.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
            => _employeeRepository = employeeRepository;

        public async Task<Employee> AuthenticationByUsernameAsync(Employee employee)
            => await _employeeRepository.AuthenticationByUsernameAsync(employee);


        public async Task<Employee> AuthenticationByBarcodeAsync(Employee employee)
            => await _employeeRepository.AuthenticationByBarcodeAsync(employee);
    }
}