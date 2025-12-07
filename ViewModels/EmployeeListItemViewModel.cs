namespace EmployeeManagementSystem.ViewModels
{
    public class EmployeeListItemViewModel
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public string Department { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
