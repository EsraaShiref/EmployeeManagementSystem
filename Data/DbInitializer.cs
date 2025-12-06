using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Employees.Any())
                return; // already seeded

            var Employees = new List<Employee>
            {
                new Employee{ FirstName="John", LastName="Doe", Department=Employee.DepartmentEnum.HR, IsActive=true, EmailAddress="john.doe@example.com", Phone="01010010001", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2020-12-01")},
                new Employee{ FirstName="Jane", LastName="Smith", Department=Employee.DepartmentEnum.Finance, IsActive=false, EmailAddress="jane.smith@example.com", Phone="01010010002", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-03-15")},
                new Employee{ FirstName="Ali", LastName="Khan", Department=Employee.DepartmentEnum.IT, IsActive=true, EmailAddress="ali.khan@example.com", Phone="01010010003", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-08-22")},
                new Employee{ FirstName="Maria", LastName="Gomez", Department=Employee.DepartmentEnum.Marketing, IsActive=false, EmailAddress="maria.gomez@example.com", Phone="01010010004", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-11-09")},
                new Employee{ FirstName="David", LastName="Brown", Department=Employee.DepartmentEnum.Operations, IsActive=true, EmailAddress="david.brown@example.com", Phone="01010010005", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-06-30")},

                new Employee{ FirstName="Wei", LastName="Li", Department=Employee.DepartmentEnum.IT, IsActive=true, EmailAddress="wei.li@example.com", Phone="01010010006", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2023-01-17")},
                new Employee{ FirstName="Aisha", LastName="Ahmed", Department=Employee.DepartmentEnum.HR, IsActive=false, EmailAddress="aisha.ahmed@example.com", Phone="01010010007", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2019-05-05")},
                new Employee{ FirstName="Carlos", LastName="Santos", Department=Employee.DepartmentEnum.Finance, IsActive=true, EmailAddress="carlos.santos@example.com", Phone="01010010008", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2020-09-12")},
                new Employee{ FirstName="Anna", LastName="Kowalski", Department=Employee.DepartmentEnum.Marketing, IsActive=false, EmailAddress="anna.kowalski@example.com", Phone="01010010009", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2023-02-28")},
                new Employee{ FirstName="Mohamed", LastName="Hassan", Department=Employee.DepartmentEnum.Operations, IsActive=true, EmailAddress="mohamed.hassan@example.com", Phone="01010010010", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-07-19")},

                new Employee{ FirstName="Sara", LastName="Connor", Department=Employee.DepartmentEnum.HR, IsActive=false, EmailAddress="sara.connor@example.com", Phone="01010010011", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-01-25")},
                new Employee{ FirstName="James", LastName="Wilson", Department=Employee.DepartmentEnum.Finance, IsActive=true, EmailAddress="james.wilson@example.com", Phone="01010010012", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-05-14")},
                new Employee{ FirstName="Fatima", LastName="Youssef", Department=Employee.DepartmentEnum.IT, IsActive=true, EmailAddress="fatima.youssef@example.com", Phone="01010010013", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-09-09")},
                new Employee{ FirstName="Liam", LastName="O'Connor", Department=Employee.DepartmentEnum.Marketing, IsActive=false, EmailAddress="liam.oconnor@example.com", Phone="01010010014", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2023-03-30")},
                new Employee{ FirstName="Emily", LastName="Blunt", Department=Employee.DepartmentEnum.Operations, IsActive=true, EmailAddress="emily.blunt@example.com", Phone="01010010015", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-08-12")},

                new Employee{ FirstName="Noah", LastName="Brown", Department=Employee.DepartmentEnum.HR, IsActive=false, EmailAddress="noah.brown@example.com", Phone="01010010016", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-12-01")},
                new Employee{ FirstName="Oliver", LastName="Smith", Department=Employee.DepartmentEnum.Finance, IsActive=true, EmailAddress="oliver.smith@example.com", Phone="01010010017", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-04-21")},
                new Employee{ FirstName="Sophia", LastName="Taylor", Department=Employee.DepartmentEnum.IT, IsActive=false, EmailAddress="sophia.taylor@example.com", Phone="01010010018", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2023-07-19")},
                new Employee{ FirstName="Isabella", LastName="Martinez", Department=Employee.DepartmentEnum.Marketing, IsActive=true, EmailAddress="isabella.martinez@example.com", Phone="01010010019", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2020-11-11")},
                new Employee{ FirstName="Ethan", LastName="Clark", Department=Employee.DepartmentEnum.Operations, IsActive=false, EmailAddress="ethan.clark@example.com", Phone="01010010020", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-06-05")},

                new Employee{ FirstName="William", LastName="Johnson", Department=Employee.DepartmentEnum.HR, IsActive=true, EmailAddress="william.johnson@example.com", Phone="01010010021", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-10-23")},
                new Employee{ FirstName="Mia", LastName="Davis", Department=Employee.DepartmentEnum.Finance, IsActive=false, EmailAddress="mia.davis@example.com", Phone="01010010022", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2023-01-15")},
                new Employee{ FirstName="Benjamin", LastName="Miller", Department=Employee.DepartmentEnum.IT, IsActive=true, EmailAddress="benjamin.miller@example.com", Phone="01010010023", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-02-28")},
                new Employee{ FirstName="Lucas", LastName="Garcia", Department=Employee.DepartmentEnum.Marketing, IsActive=false, EmailAddress="lucas.garcia@example.com", Phone="01010010024", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-08-18")},
                new Employee{ FirstName="Charlotte", LastName="Lopez", Department=Employee.DepartmentEnum.Operations, IsActive=true, EmailAddress="charlotte.lopez@example.com", Phone="01010010025", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-05-12")},

                new Employee{ FirstName="Amelia", LastName="Hernandez", Department=Employee.DepartmentEnum.HR, IsActive=false, EmailAddress="amelia.hernandez@example.com", Phone="01010010026", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2023-09-01")},
                new Employee{ FirstName="Henry", LastName="Lopez", Department=Employee.DepartmentEnum.Finance, IsActive=true, EmailAddress="henry.lopez@example.com", Phone="01010010027", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-11-19")},
                new Employee{ FirstName="Alexander", LastName="Wilson", Department=Employee.DepartmentEnum.IT, IsActive=false, EmailAddress="alexander.wilson@example.com", Phone="01010010028", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2022-07-07")},
                new Employee{ FirstName="Ella", LastName="Moore", Department=Employee.DepartmentEnum.Marketing, IsActive=true, EmailAddress="ella.moore@example.com", Phone="01010010029", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2023-04-25")},
                new Employee{ FirstName="Daniel", LastName="Taylor", Department=Employee.DepartmentEnum.Operations, IsActive=false, EmailAddress="daniel.taylor@example.com", Phone="01010010030", RowGuid=Guid.NewGuid(), JoinedDate=DateTime.Parse("2021-09-30")}
            };

            context.Employees.AddRange(Employees);
            context.SaveChanges();
        }
    }
}
