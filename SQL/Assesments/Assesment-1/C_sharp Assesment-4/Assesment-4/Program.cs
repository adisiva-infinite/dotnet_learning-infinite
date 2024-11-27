using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_4
{
    public class Employee
    {
        public int EmployeeID;
        public string FirstName;
        public string LastName;
        public string Title;
        public DateTime DOB;
        public DateTime DOJ;
        public string City;
    }
    public class Program
    {
        public static void Main()
        {
            // Creating the list of employees
            List<Employee> employeeList = new List<Employee>
                {
new Employee {
    EmployeeID = 1001,
    FirstName = "Malcolm",
    LastName = "Daruwalla",
    Title = "Manager",
    DOB = new DateTime(1984, 11, 16),
    DOJ = new DateTime(2011, 6, 8),
    City = "Mumbai"
},
new Employee {
    EmployeeID = 1002,
    FirstName = "Asdin",
    LastName = "Dhalla",
    Title = "AsstManager",
    DOB = new DateTime(1994, 8, 20),
    DOJ = new DateTime(2012, 7, 7),
    City = "Mumbai"
},
new Employee {
    EmployeeID = 1003,
    FirstName = "Madhavi",
    LastName = "Oza",
    Title = "Consultant",
    DOB = new DateTime(1987, 11, 14),
    DOJ = new DateTime(2015, 4, 12),
    City = "Pune"
},
new Employee {
    EmployeeID = 1004,
    FirstName = "Saba",
    LastName = "Shaikh",
    Title = "SE",
    DOB = new DateTime(1990, 6, 3),
    DOJ = new DateTime(2016, 2, 2),
    City = "Pune"
},
new Employee {
    EmployeeID = 1005,
    FirstName = "Nazia",
    LastName = "Shaikh",
    Title = "SE",
    DOB = new DateTime(1991, 3, 8),
    DOJ = new DateTime(2016, 2, 2),
    City = "Mumbai"
},
new Employee {
    EmployeeID = 1006,
    FirstName = "Amit",
    LastName = "Pathak",
    Title = "Consultant",
    DOB = new DateTime(1989, 11, 7),
    DOJ = new DateTime(2014, 8, 8),
    City = "Chennai"
},
new Employee {
    EmployeeID = 1007,
    FirstName = "Vijay",
    LastName = "Natrajan",
    Title = "Consultant",
    DOB = new DateTime(1989, 12, 2),
    DOJ = new DateTime(2015, 6, 1),
    City = "Mumbai"
},
new Employee {
    EmployeeID = 1008,
    FirstName = "Rahul",
    LastName = "Dubey",
    Title = "Associate",
    DOB = new DateTime(1993, 11, 11),
    DOJ = new DateTime(2014, 11, 6),
    City = "Chennai"
},
new Employee {
    EmployeeID = 1009,
    FirstName = "Suresh",
    LastName = "Mistry",
    Title = "Associate",
    DOB = new DateTime(1992, 8, 12),
    DOJ = new DateTime(2014, 12, 3),
    City = "Chennai"
},
new Employee {
    EmployeeID = 1010,
    FirstName = "Sumit",
    LastName = "Shah",
    Title = "Manager",
    DOB = new DateTime(1991, 4, 12),
    DOJ = new DateTime(2016, 1, 2),
    City = "Pune"
}
            };

            // Display detail of all the employee
            var AllEmployees = employeeList;
            Console.WriteLine("All Employee Details:");
            Console.WriteLine();
            foreach (var e1 in AllEmployees)
            {
                Console.WriteLine($"{e1.EmployeeID} {e1.FirstName} {e1.LastName} {e1.Title} {e1.DOB.ToShortDateString()} {e1.DOJ.ToShortDateString()} {e1.City}");
              //  Console.WriteLine();
            }

            // Display details of all the employee whose location is not Mumbai
            var ExceptMumbaiEmployees = employeeList.Where(e => e.City != "Mumbai");
            Console.WriteLine();
            Console.WriteLine(" Employees Not in Mumbai : ");
            Console.WriteLine();
            foreach (var e2 in ExceptMumbaiEmployees)
            {
                Console.WriteLine($"{e2.EmployeeID} {e2.FirstName} {e2.LastName} {e2.City}");
            }

            // Display details of employees with the title 'AsstManager'
            var AsstManager = employeeList.Where(e => e.Title == "AsstManager");
            Console.WriteLine();
            Console.WriteLine(" AsstManager : ");
            Console.WriteLine();
            foreach (var e3 in AsstManager)
            {
                Console.WriteLine($"{e3.EmployeeID} {e3.FirstName} {e3.LastName} {e3.Title}");
            }

            // Display details of employees whose last name starts with 'S'
            var employeesWith_S = employeeList.Where(e => e.LastName.StartsWith("S"));
            Console.WriteLine(" Employees Whose Last Name Starts with S : ");
            foreach (var e4 in employeesWith_S)
            {
                Console.WriteLine($"{e4.EmployeeID} {e4.FirstName} {e4.LastName}");
            }
            Console.ReadKey();
        }
    }
}
