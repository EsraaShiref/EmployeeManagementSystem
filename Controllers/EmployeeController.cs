using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private const int PageSize = 6; // عدد السجلات لكل صفحة

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // ======================================================
        // INDEX (List + Sort + Search + Pagination)
        // ======================================================
        public async Task<IActionResult> Index(string sortOrder, string searchString, int page = 1)
        {
            // جلب كل البيانات أولاً لتجنب مشكلة ToString على enum
            var employees = await _context.Employees.ToListAsync();

            // SEARCH
            if (!string.IsNullOrEmpty(searchString))
            {
                string lower = searchString.ToLower();
                employees = employees
                    .Where(e =>
                        e.FirstName.ToLower().Contains(lower) ||
                        e.LastName.ToLower().Contains(lower) ||
                        e.EmailAddress.ToLower().Contains(lower) ||
                        e.Department.ToString().ToLower().Contains(lower))
                    .ToList();
            }

            // SORTING
            employees = sortOrder switch
            {
                "FullName" => employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList(),
                "FullName_desc" => employees.OrderByDescending(e => e.FirstName).ThenByDescending(e => e.LastName).ToList(),
                "Department" => employees.OrderBy(e => e.Department).ToList(),
                "Department_desc" => employees.OrderByDescending(e => e.Department).ToList(),
                "JoinedDate" => employees.OrderBy(e => e.JoinedDate).ToList(),
                "JoinedDate_desc" => employees.OrderByDescending(e => e.JoinedDate).ToList(),
                _ => employees.OrderBy(e => e.EmployeeID).ToList(),
            };

            // Pagination
            int totalRecords = employees.Count;
            int totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);

            if (page < 1)
                page = 1;
            if (page > totalPages && totalPages > 0)
                page = totalPages;

            var pagedEmployees = employees
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            // تمرير البيانات للـ View عبر ViewData
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(pagedEmployees);
        }

        // ======================================================
        // DETAILS
        // ======================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // ======================================================
        // CREATE (GET)
        // ======================================================
        public IActionResult Create()
        {
            return View();
        }

        // ======================================================
        // CREATE (POST)
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Department,FirstName,LastName,IsActive,EmailAddress,Phone")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.JoinedDate = DateTime.Now;
                _context.Add(employee);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Employee added successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // ======================================================
        // EDIT (GET)
        // ======================================================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // ======================================================
        // EDIT (POST)
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,Department,FirstName,LastName,IsActive,EmailAddress,Phone,RowGuid,JoinedDate")] Employee employee)
        {
            if (id != employee.EmployeeID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    employee.JoinedDate = DateTime.Now;
                    _context.Update(employee);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Employee updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Employees.Any(e => e.EmployeeID == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // ======================================================
        // DELETE (GET)
        // ======================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // ======================================================
        // DELETE (POST)
        // ======================================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Employee deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
