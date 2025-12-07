using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        // Query returns AsNoTracking so listing operations don't track by default.
        public IQueryable<Employee> Query() => _context.Employees.AsNoTracking();

        public async Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default) =>
            await _context.Employees.FindAsync(new object?[] { id }, ct);

        public async Task AddAsync(Employee entity, CancellationToken ct = default)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Employee entity, CancellationToken ct = default)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Employee entity, CancellationToken ct = default)
        {
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
