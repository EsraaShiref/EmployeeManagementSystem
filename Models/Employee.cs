using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        public DepartmentEnum? Department { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }  // made nullable (optional)

        public string? Phone { get; set; } // made nullable (optional)

        public bool IsActive { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;

        public enum DepartmentEnum
        {
            HR,
            IT,
            Sales,
            Finance,
            Marketing
        }
    }
}
