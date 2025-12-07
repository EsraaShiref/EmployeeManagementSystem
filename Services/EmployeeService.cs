using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModels;
using EmployeeManagementSystem.Repositories;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo) => _repo = repo;

        public async Task<EmployeeListViewModel> GetEmployeesAsync(
    string? sortOrder,
    string? searchString,
    int page = 1,
    Employee.DepartmentEnum? department = null,
    bool? isActive = null,
    CancellationToken ct = default)
        {
            const int PageSize = 5;

            var query = _repo.Query(); // AsNoTracking from repository

            // 1) فلترة البحث
            var term = (searchString ?? string.Empty).Trim();
            if (!string.IsNullOrEmpty(term))
            {
                var lowerTerm = term.ToLower();
                query = query.Where(e =>
                    ((e.FirstName ?? "").ToLower().Contains(lowerTerm)) ||
                    ((e.LastName ?? "").ToLower().Contains(lowerTerm)) ||
                    ((e.EmailAddress ?? "").ToLower().Contains(lowerTerm))
                );
            }

            // 2) apply advanced filters
            if (department.HasValue)
                query = query.Where(e => e.Department == department.Value);

            if (isActive.HasValue)
                query = query.Where(e => e.IsActive == isActive.Value);

            // 3) sorting
            query = sortOrder switch
            {
                "name_desc" => query.OrderByDescending(e => e.FirstName).ThenByDescending(e => e.LastName),
                "department" => query.OrderBy(e => e.Department),
                "department_desc" => query.OrderByDescending(e => e.Department),
                _ => query.OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
            };

            // 4) pagination
            var totalEmployees = await query.CountAsync(ct);
            var totalPages = (int)Math.Ceiling(totalEmployees / (double)PageSize);
            if (totalPages == 0) totalPages = 1;
            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            var employees = await query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(e => new EmployeeListItemViewModel
                {
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName ?? string.Empty,
                    LastName = e.LastName ?? string.Empty,
                    Department = e.Department.ToString(),
                    EmailAddress = e.EmailAddress ?? string.Empty,
                    Phone = e.Phone ?? string.Empty,
                    IsActive = e.IsActive,
                    JoinedDate = e.JoinedDate
                })
                .ToListAsync(ct);

            return new EmployeeListViewModel
            {
                Employees = employees,
                CurrentPage = page,
                TotalPages = totalPages,
                CurrentFilter = searchString ?? string.Empty,
                CurrentSort = sortOrder ?? string.Empty
            };
        }

        public async Task<EmployeeDetailsViewModel?> GetEmployeeDetailsAsync(int id, CancellationToken ct = default)
        {
            var e = await _repo.GetByIdAsync(id, ct);
            if (e == null) return null;

            return new EmployeeDetailsViewModel
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName ?? string.Empty,
                LastName = e.LastName ?? string.Empty,
                Department = e.Department.ToString(),
                EmailAddress = e.EmailAddress ?? string.Empty,
                Phone = e.Phone ?? string.Empty,
                IsActive = e.IsActive,
                JoinedDate = e.JoinedDate
            };
        }

        public async Task<EmployeeDeleteViewModel?> GetEmployeeForDeleteAsync(int id, CancellationToken ct = default)
        {
            var e = await _repo.GetByIdAsync(id, ct);
            if (e == null) return null;

            return new EmployeeDeleteViewModel
            {
                EmployeeID = e.EmployeeID,
                FullName = (e.FirstName ?? "") + " " + (e.LastName ?? ""),
                Department = e.Department.ToString(),
                EmailAddress = e.EmailAddress ?? string.Empty,
                Phone = e.Phone ?? string.Empty,
                JoinedDate = e.JoinedDate,
                IsActive = e.IsActive
            };
        }

        public async Task AddEmployeeAsync(EmployeeCreateViewModel model, CancellationToken ct = default)
        {
            var email = (model.EmailAddress ?? string.Empty).Trim();
            if (!string.IsNullOrEmpty(email))
            {
                var exists = await _repo.Query().AnyAsync(e => (e.EmailAddress ?? "") == email, ct);
                if (exists)
                    throw new InvalidOperationException("An employee with the same email already exists.");
            }

            var employee = new Employee
            {
                FirstName = model.FirstName?.Trim(),
                LastName = model.LastName?.Trim(),
                Department = model.Department ?? Employee.DepartmentEnum.IT,
                EmailAddress = string.IsNullOrWhiteSpace(email) ? null : email,
                Phone = string.IsNullOrWhiteSpace(model.Phone) ? null : model.Phone.Trim(),
                IsActive = model.IsActive,
                JoinedDate = model.JoinedDate
            };

            await _repo.AddAsync(employee, ct);
        }

        public async Task UpdateEmployeeAsync(EmployeeEditViewModel model, CancellationToken ct = default)
        {
            var e = await _repo.GetByIdAsync(model.EmployeeID, ct);
            if (e == null) return;

            var email = (model.EmailAddress ?? string.Empty).Trim();
            if (!string.IsNullOrEmpty(email))
            {
                var exists = await _repo.Query()
                    .AnyAsync(x => (x.EmailAddress ?? "") == email && x.EmployeeID != model.EmployeeID, ct);
                if (exists)
                    throw new InvalidOperationException("Another employee with the same email already exists.");
            }

            e.FirstName = model.FirstName?.Trim();
            e.LastName = model.LastName?.Trim();
            e.Department = model.Department ?? e.Department;
            e.EmailAddress = string.IsNullOrWhiteSpace(email) ? null : email;
            e.Phone = string.IsNullOrWhiteSpace(model.Phone) ? null : model.Phone.Trim();
            e.IsActive = model.IsActive;
            e.JoinedDate = model.JoinedDate;

            await _repo.UpdateAsync(e, ct);
        }

        public async Task DeleteEmployeeAsync(int id, CancellationToken ct = default)
        {
            var e = await _repo.GetByIdAsync(id, ct);
            if (e != null)
            {
                await _repo.DeleteAsync(e, ct);
            }
        }
    }
}
