using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using EmployeeManagementSystem.ViewModels;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service) => _service = service;

        public async Task<IActionResult> Index(
    string sortOrder,
    string searchString,
    int page = 1,
    Employee.DepartmentEnum? department = null,
    bool? isActive = null,
    CancellationToken ct = default)  // شلنا joinedFrom و joinedTo
        {
            ViewData["CurrentSort"] = sortOrder ?? string.Empty;
            ViewData["CurrentFilter"] = searchString ?? string.Empty;
            ViewData["CurrentDepartment"] = department?.ToString() ?? string.Empty;
            ViewData["CurrentIsActive"] = isActive?.ToString() ?? string.Empty;

            var model = await _service.GetEmployeesAsync(sortOrder, searchString, page, department, isActive, ct);
            return View(model);
        }


        public IActionResult Create() => View(new EmployeeCreateViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model, CancellationToken ct = default)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                await _service.AddEmployeeAsync(model, ct);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id, CancellationToken ct = default)
        {
            var details = await _service.GetEmployeeDetailsAsync(id, ct);
            if (details == null) return NotFound();

            var model = new EmployeeEditViewModel
            {
                EmployeeID = details.EmployeeID,
                FirstName = details.FirstName,
                LastName = details.LastName,
                Department = Enum.TryParse<Employee.DepartmentEnum>(details.Department, out var dep) ? dep : null,
                EmailAddress = details.EmailAddress,
                Phone = details.Phone,
                IsActive = details.IsActive,
                JoinedDate = details.JoinedDate
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model, CancellationToken ct = default)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                await _service.UpdateEmployeeAsync(model, ct);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        public async Task<IActionResult> Details(int id, CancellationToken ct = default)
        {
            var model = await _service.GetEmployeeDetailsAsync(id, ct);
            if (model == null) return NotFound();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id, CancellationToken ct = default)
        {
            var model = await _service.GetEmployeeForDeleteAsync(id, ct);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EmployeeID, CancellationToken ct = default)
        {
            await _service.DeleteEmployeeAsync(EmployeeID, ct);
            return RedirectToAction(nameof(Index));
        }
    }
}
