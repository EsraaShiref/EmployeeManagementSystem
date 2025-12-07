using System;
using System.Linq;

using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // لو فيه بيانات بالفعل، منع التكرار
            if (context.Employees.Any()) return;

            var random = new Random();

            var employees = new Employee[]
            {
                new Employee { FirstName = "John", LastName = "Doe", Department = Employee.DepartmentEnum.IT, EmailAddress = "john.doe@example.com", Phone="01011112222", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Jane", LastName = "Smith", Department = Employee.DepartmentEnum.HR, EmailAddress = "jane.smith@example.com", Phone="01022223333", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Michael", LastName = "Johnson", Department = Employee.DepartmentEnum.Finance, EmailAddress = "michael.johnson@example.com", Phone="01033334444", IsActive=false, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Emily", LastName = "Davis", Department = Employee.DepartmentEnum.Marketing, EmailAddress = "emily.davis@example.com", Phone="01044445555", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Daniel", LastName = "Wilson", Department = Employee.DepartmentEnum.IT, EmailAddress = "daniel.wilson@example.com", Phone="01055556666", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Sophia", LastName = "Brown", Department = Employee.DepartmentEnum.HR, EmailAddress = "sophia.brown@example.com", Phone="01066667777", IsActive=false, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "James", LastName = "Taylor", Department = Employee.DepartmentEnum.Finance, EmailAddress = "james.taylor@example.com", Phone="01077778888", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Olivia", LastName = "Anderson", Department = Employee.DepartmentEnum.Marketing, EmailAddress = "olivia.anderson@example.com", Phone="01088889999", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "William", LastName = "Thomas", Department = Employee.DepartmentEnum.IT, EmailAddress = "william.thomas@example.com", Phone="01099990000", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Ava", LastName = "Jackson", Department = Employee.DepartmentEnum.HR, EmailAddress = "ava.jackson@example.com", Phone="01111112222", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Alexander", LastName = "White", Department = Employee.DepartmentEnum.Finance, EmailAddress = "alexander.white@example.com", Phone="01122223333", IsActive=false, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Mia", LastName = "Harris", Department = Employee.DepartmentEnum.Marketing, EmailAddress = "mia.harris@example.com", Phone="01133334444", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Benjamin", LastName = "Martin", Department = Employee.DepartmentEnum.IT, EmailAddress = "benjamin.martin@example.com", Phone="01144445555", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Isabella", LastName = "Thompson", Department = Employee.DepartmentEnum.HR, EmailAddress = "isabella.thompson@example.com", Phone="01155556666", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Lucas", LastName = "Garcia", Department = Employee.DepartmentEnum.Finance, EmailAddress = "lucas.garcia@example.com", Phone="01166667777", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Liam", LastName = "Scott", Department = Employee.DepartmentEnum.Sales, EmailAddress = "liam.scott@example.com", Phone="01177778888", IsActive=true, JoinedDate = RandomDate(random) },
                new Employee { FirstName = "Charlotte", LastName = "Lee", Department = Employee.DepartmentEnum.Sales, EmailAddress = "charlotte.lee@example.com", Phone="01188889999", IsActive=false, JoinedDate = RandomDate(random) }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }

        private static DateTime RandomDate(Random random)
        {
            var start = DateTime.UtcNow.AddYears(-2); // قبل سنتين
            int range = (DateTime.UtcNow - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
