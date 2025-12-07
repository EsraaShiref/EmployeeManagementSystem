# Employee Management System

This is a simple **Employee Management System** built with **ASP.NET Core MVC** and **Entity Framework Core**. It demonstrates basic CRUD operations, safe data filtering, and clean separation of concerns using **Controllers**, **Services**, **Repositories**, and **ViewModels**.

---

## Features

* **Employee CRUD**

  * Create, read, update, and delete employee records.
  * Safe email validation to prevent duplicates.
  * Status management (Active / Inactive) for employees.

* **Filtering and Sorting**

  * Search employees by name or email safely.
  * Filter by department or active status.
  * Sort by name or department.

* **Pagination**

  * Server-side pagination to handle large datasets efficiently.

* **View Models**

  * Separate **ViewModels** for create, edit, delete, details, and listing views.
  * Avoids exposing Entity models directly to views.

* **UI**

  * Responsive and modern interface using Bootstrap.
  * Clear separation between filter controls, tables, and pagination.
  * Safe handling of null or empty fields in UI and search.

* **Database Handling**

  * All filtering, sorting, and paging is executed at the database level.
  * Prevents loading all data into memory to improve performance.
  * Uses **Repository** pattern for database communication via **Entity Framework Core**.

---

## Technologies Used

* **ASP.NET Core MVC** (.NET 8)
* **Entity Framework Core**
* **SQL Server** (local or remote)
* **Bootstrap 5**
* **C#**
* **Git** for version control

---

## Project Structure

```
EmployeeManagementSystem/
│
├─ Controllers/         # Handles HTTP requests and returns Views
├─ Models/              # Entity models representing database tables
├─ ViewModels/          # View-specific models for safer data handling
├─ Services/            # Business logic and database operations
├─ Repositories/        # Database access abstraction
├─ Views/               # Razor views for UI
├─ wwwroot/             # CSS, JS, and static assets
└─ Data/                # DbContext and database initializer
```

---

## Getting Started

1. **Clone the repository:**

```bash
git clone https://github.com/EsraaShiref/EmployeeManagementSystem.git
cd EmployeeManagementSystem
```

2. **Configure the database:**

* Update `appsettings.json` with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

3. **Apply migrations and seed the database:**

```bash
dotnet ef database update
```

4. **Run the application:**

```bash
dotnet run
```

5. Open your browser at [https://localhost:5001](https://localhost:5001) to see the app.

---

## Notes on Implementation

* All **filtering, sorting, and paging** is done at the database level for performance.
* All input fields are **trimmed and validated** before queries.
* Null-safe operations prevent runtime errors when data is missing.
* Entity models are **never used directly in views**; ViewModels ensure separation of concerns.
* Services handle communication with repositories; controllers are thin and handle HTTP requests only.

---

## License

This project is open-source and free to use.
