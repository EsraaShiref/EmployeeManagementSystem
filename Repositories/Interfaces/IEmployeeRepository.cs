using EmployeeManagementSystem.Models;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Query();
        Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(Employee entity, CancellationToken ct = default);
        Task UpdateAsync(Employee entity, CancellationToken ct = default);
        Task DeleteAsync(Employee entity, CancellationToken ct = default);
    }
}
