using System.Threading.Tasks;
using Serko.Core.Domain.Entities;

namespace Serko.Core.Domain.Interfaces.ApplicationService
{
    public interface IEmployeeApplicationService : IBaseApplicationService
    {
        Task<Employee> AuthenticationAsync(dynamic request);
    }
}