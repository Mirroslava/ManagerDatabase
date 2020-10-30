using ManagerDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerDatabase
{
    public class SampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            Manager manager1 = new Manager
            {
                Name = "Ivan",
                DateOfBirth = new DateTime(1999, 1, 1),
                Married = false,
                Phone = "0123456784",
                Salary = 18700

            };
            Manager manager2 = new Manager
            {
                Name = "Lia",
                DateOfBirth = new DateTime(1993, 5, 2),
                Married = false,
                Phone = "0123456784",
                Salary = 16700

            };
            Manager manager3 = new Manager
            {
                Name = "Igor",
                DateOfBirth = new DateTime(1984, 12, 26),
                Married = true,
                Phone = "0123456784",
                Salary = 22300

            };
            Manager manager4 = new Manager
            {
                Name = "Harry",
                DateOfBirth = new DateTime(1976, 6, 6),
                Married = true,
                Phone = "0123456784",
                Salary = 45000

            };
            Manager manager5 = new Manager
            {
                Name = "Oleg",
                DateOfBirth = new DateTime(1995, 3, 25),
                Married = false,
                Phone = "0123456784",
                Salary = 12100

            };
            Manager manager6 = new Manager
            {
                Name = "Olena",
                DateOfBirth = new DateTime(1999, 11, 16),
                Married = false,
                Phone = "0123456784",
                Salary = 10200

            };
            Manager manager7 = new Manager
            {
                Name = "Stiven",
                DateOfBirth = new DateTime(1999, 4, 1),
                Married = true,
                Phone = "0123456784",
                Salary = 15700

            };
            Manager manager8 = new Manager
            {
                Name = "Ilona",
                DateOfBirth = new DateTime(1989, 2, 5),
                Married = false,
                Phone = "0123456784",
                Salary = 9700

            };
            Manager manager9 = new Manager
            {
                Name = "Vika",
                DateOfBirth = new DateTime(1979, 3, 6),
                Married = true,
                Phone = "0123456784",
                Salary = 19700

            };
            Manager manager10 = new Manager
            {
                Name = "Liza",
                DateOfBirth = new DateTime(1987, 2, 7),
                Married = true,
                Phone = "0123456784",
                Salary = 21400

            };
            if (!context.Managers.Any())
            {
                context.Managers.AddRange(
                    manager1,
                    manager2,
                    manager3,
                    manager4,
                    manager5,
                    manager6,
                    manager7,
                    manager8,
                    manager9,
                    manager10);
                context.SaveChanges();
            }

        }
    }
}