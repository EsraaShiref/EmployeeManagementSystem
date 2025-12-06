# Employee Management System - ASP.NET Core 8 MVC

A production-ready ASP.NET Core 8 MVC template demonstrating enterprise-grade CRUD operations for employee management, with advanced features including sorting, searching, pagination, and responsive Bootstrap UI.

---

## 🚀 Features
- ✅ Complete CRUD Operations - Create, Read, Update, Delete employee records
- 🔍 Advanced Search - Multi-field search across employee attributes
- 🔃 Dynamic Sorting - Click-to-sort on all table columns (ascending/descending)
- 📄 Pagination - Efficient data loading with configurable page size
- 📱 Responsive Design - Bootstrap 5 mobile-first interface
- 🗄️ Database Seeding - Automatic initialization with sample data
- 🔗 Entity Framework Core - Code-first approach with SQL Server
- ✔️ Form Validation - Client and server-side validation
- 💬 Success Notifications - User feedback with TempData alerts

---

## 📸 Screenshots
### Employee List View
![Comprehensive data table with multi-column search, sortable headers, and pagination controls.](Assets/screenshot1.png)

### Create New Employee
![Clean, responsive form with Bootstrap 5 styling and validated input fields.](Assets/screenshot3.png)

### Edit Employee
![Edit form pre-populated with existing employee data, maintaining consistent UI.](Assets/screenshot5.png)

### Employee Details
![Read-only view displaying complete employee information with action buttons.](Assets/screenshot4.png)

### Delete Confirmation
![Safety confirmation dialog to prevent accidental data loss.](Assets/screenshot6.png)

### Search&sort 
![Employee List](Assets/screenshot7.png)

---

## 📋 Prerequisites
- .NET 8.0 SDK or higher
- SQL Server (Express/Developer/Standard)
- Visual Studio 2022 or VS Code
- Basic knowledge of C# and ASP.NET Core MVC

---

## 🛠️ Technology Stack

| Category    | Technologies                     |
|------------|----------------------------------|
| Framework  | ASP.NET Core 8 MVC               |
| Language   | C# 12                            |
| ORM        | Entity Framework Core 8          |
| Database   | Microsoft SQL Server             |
| Frontend   | Bootstrap 5.3, jQuery 3.6       |
| Validation | jQuery Validation & Unobtrusive  |
| Architecture | MVC Pattern                     |

---

## ⚙️ Installation & Setup

1. **Clone the Repository**
```bash
git clone https://github.com/EsraaShiref/EmployeeManagementSystem.git
cd EmployeeManagementSystem
```

2. **Configure Database Connection**  
Update `appsettings.json` with your SQL Server connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

3. **Restore Dependencies**
```bash
dotnet restore
```

4. **Run the Application**
```bash
dotnet run
```

The application will automatically:
- Create the database if it doesn't exist
- Seed initial employee data
- Launch at `https://localhost:5001`

---

## 📁 Project Structure

```
EmployeeManagementSystem/
├── Controllers/
│   └── EmployeeController.cs      # Main CRUD logic with sorting/filtering
├── Data/
│   ├── AppDbContext.cs            # EF Core DbContext
│   └── DbInitializer.cs           # Database seeding logic
├── Models/
│   └── Employee.cs                # Employee entity model
├── Views/
│   ├── Employee/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _Navbar.cshtml
│       ├── _Pagination.cshtml
│       └── _SortableColumn.cshtml
├── wwwroot/
│   ├── css/
│   └── js/
├── .editorconfig
├── .gitignore
├── README.md
├── appsettings.json
└── Program.cs
```

---

## 🎯 Key Implementation Highlights

### Pagination Logic
```csharp
int totalRecords = await employees.CountAsync();
int totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);

var paginatedList = await employees
    .Skip((pageNumber - 1) * PageSize)
    .Take(PageSize)
    .ToListAsync();
```

### Multi-Column Search
```csharp
employees = employees.Where(e =>
    (e.FirstName != null && e.FirstName.ToLower().Contains(lowerSearch)) ||
    (e.LastName != null && e.LastName.ToLower().Contains(lowerSearch)) ||
    (e.Email != null && e.Email.ToLower().Contains(lowerSearch)) ||
    (e.Department != null && e.Department.ToLower().Contains(lowerSearch))
);
```

### Dynamic Sorting
```csharp
employees = sortOrder switch
{
    "FirstName" => employees.OrderBy(e => e.FirstName),
    "FirstName_desc" => employees.OrderByDescending(e => e.FirstName),
    "LastName" => employees.OrderBy(e => e.LastName),
    _ => employees.OrderBy(e => e.FirstName)
};
```

---

## 🔧 Customization

**Change Page Size**  
In `EmployeeController.cs`:
```csharp
private const int PageSize = 6; // Modify this value
```

**Add New Fields**
1. Update `Employee.cs` model  
2. Create migration:
```bash
dotnet ef migrations add AddNewField
```
3. Update database:
```bash
dotnet ef database update
```
4. Update views to display new fields

**Change Database Provider**  
Replace SQL Server with PostgreSQL, MySQL, or SQLite by updating:
- NuGet packages
- Connection string in `appsettings.json`
- `UseSqlServer()` in `Program.cs`

---

## 🧪 Testing

Manual Testing Checklist:
- Create new employee record
- Edit existing employee
- Delete employee with confirmation
- Search by name, email, department
- Sort by each column (asc/desc)
- Navigate through pagination
- Validate form inputs
- Test responsive layout on mobile

---

## 📚 Learning Outcomes

This project demonstrates proficiency in:
- ASP.NET Core MVC architecture
- Entity Framework Core ORM
- LINQ query optimization
- Asynchronous programming (async/await)
- Bootstrap responsive design
- Client-side and server-side validation
- Partial views and view components
- TempData for cross-request messaging
- Database initialization and seeding

---


## 🙏 Acknowledgments

- Bootstrap - For the excellent CSS framework  
- Microsoft - For ASP.NET Core and Entity Framework Core  
- Open-source community for continuous inspiration
