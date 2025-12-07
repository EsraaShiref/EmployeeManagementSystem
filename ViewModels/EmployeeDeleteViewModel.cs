namespace EmployeeManagementSystem.ViewModels
{
    public class EmployeeDeleteViewModel
    {
        public int EmployeeID { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
