using System.ComponentModel.DataAnnotations;

using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.ViewModels
{
    public class EmployeeEditViewModel
    {
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Employee.DepartmentEnum? Department { get; set; }

        [EmailAddress]
        [StringLength(200)]
        public string? EmailAddress { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[0-9\-\+\s\(\)]{3,20}$", ErrorMessage = "Phone number contains invalid characters.")]
        public string? Phone { get; set; }

        public bool IsActive { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
