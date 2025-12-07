# Employee Management System

A simple web application built with ASP.NET Core MVC using **Razor Views** for managing employee data. The project demonstrates basic CRUD operations, server-side filtering, sorting, pagination, and safe database handling.

## Features

* List all employees with pagination
* Create, edit, view details, and delete employees
* Filter employees by department and active status
* Sort employees by name or department
* Safe handling of search inputs and null values
* Uses separate ViewModels to avoid using entities directly in views
* Database operations handled through a repository and service layer
* Bootstrap-based responsive UI with custom styling
* Razor Views only, no Blazor or SPA frameworks

## Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* C#
* Razor Views
* SQL Server
* Bootstrap 5
* Git

## Project Structure

```
EmployeeManagementSystem/
│
├─ Controllers/        # Handles HTTP requests and responses
├─ Models/             # Entity classes representing database tables
├─ ViewModels/         # Separate models used for views
├─ Services/           # Business logic and data handling
├─ Repositories/       # Database interactions (EF Core)
├─ Views/              # Razor Views for UI
├─ wwwroot/            # Static files (CSS, JS, images)
├─ Data/               # DbContext and database initialization
├─ Program.cs          # Application entry point
└─ EmployeeManagementSystem.csproj
```

## Screenshots

**Employee List Page**

![Employee List](Assets/screenshot1.png)

**Create Employee Page**

![Create Employee](Assets/screenshot2.png)

**Employee Details Page**

![Edit Employee](Assets/screenshot4.png)

**Edit Employee Page**

![Edit Employee](Assets/screenshot5.png)

**Delete Employee Page**

![Edit Employee](Assets/screenshot6.png)

**Filter&Sort**

![Edit Employee](Assets/screenshot7.png)

## Setup

1. Clone the repository:

```bash
git clone https://github.com/EsraaShiref/EmployeeManagementSystem.git
```

2. Open the solution in Visual Studio 2022 (or newer) with .NET 8 SDK installed.

3. Update the connection string in `appsettings.json` to point to your SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=EmployeeManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

4. Apply migrations and seed the database if necessary.

5. Run the project (F5 or Ctrl+F5).

## Notes

* Controllers do not contain business logic. All logic is in the **Services** layer, which communicates with **Repositories**.
* Filtering, sorting, and pagination are performed at the database level for efficiency.
* ViewModels are used to prevent exposing EF Core entities directly to Razor Views.
* Safe handling of search inputs ensures no errors occur when values are null or empty.
* Styling is done using Bootstrap with custom CSS.

## License

This project is open-source and available under the MIT License.
