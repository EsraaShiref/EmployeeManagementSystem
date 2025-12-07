using System.Collections.Generic;

namespace EmployeeManagementSystem.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeListItemViewModel> Employees { get; set; } = new();

        public string CurrentSort { get; set; } = string.Empty;
        public string CurrentFilter { get; set; } = string.Empty;

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
    }
}
