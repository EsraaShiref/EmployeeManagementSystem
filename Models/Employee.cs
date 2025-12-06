using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        // -----------------------------
        // 1) Department Enum (Dropdown)
        // -----------------------------
        public enum DepartmentEnum
        {
            [Display(Name = "Human Resources")]
            HR,
            [Display(Name = "Finance")]
            Finance,
            [Display(Name = "Information Technology")]
            IT,
            [Display(Name = "Marketing")]
            Marketing,
            [Display(Name = "Sales")]
            Sales,
            [Display(Name = "Operations")]
            Operations,
            [Display(Name = "Customer Service")]
            CustomerService,
            [Display(Name = "Engineering")]
            Engineering,
            [Display(Name = "Administration")]
            Administration
        }

        [Key]
        public int EmployeeID { get; set; }

        // -----------------------------
        // Department
        // -----------------------------
        [Required(ErrorMessage = "Department is required")]
        [Column(TypeName = "nvarchar(20)")]
        public DepartmentEnum Department { get; set; }

        // -----------------------------
        // First + Last Name
        // -----------------------------
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
        public string LastName { get; set; } = string.Empty;

        // Not mapped → للعرض فقط
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        // -----------------------------
        // Active / Company
        // -----------------------------
        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        // -----------------------------
        // Email Address
        // -----------------------------
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string EmailAddress { get; set; } = string.Empty;

        // -----------------------------
        // Phone Number
        // -----------------------------
        [StringLength(50, ErrorMessage = "Phone cannot exceed 50 characters")]
        [RegularExpression(@"^(?:\+20|0)1[0-9]{9}$", ErrorMessage = "Enter a valid Egyptian phone number")]
        public string? Phone { get; set; }

        // -----------------------------
        // Guid & JoinedDate
        // -----------------------------
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RowGuid { get; set; } = Guid.NewGuid();

        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}
