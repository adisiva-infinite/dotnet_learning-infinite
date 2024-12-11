using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Employee
    {
        public int EmployeeID;
        public string FirstName, LastName, Title, City;
        public DateTime DOB, DOJ;

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };

            //1.Display a list of all the employee who have joined before 1 / 1 / 2015

            var joinedbef = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));

            foreach (var i in joinedbef)
            {
                Console.WriteLine($"{i.EmployeeID},{i.FirstName},{i.LastName},{i.DOJ.ToShortDateString()}.");
            }
            Console.WriteLine();
            //2.Display a list of all the employee whose date of birth is after 1 / 1 / 1990


            var joinedafter = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
            foreach (var i in joinedafter)
            {
                Console.WriteLine($"{i.EmployeeID},{i.FirstName},{i.LastName},{i.DOJ.ToShortDateString()}.");
            }
            Console.WriteLine();
            //3.Display a list of all the employee whose designation is Consultant and Associate


            var desg = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            foreach (var i in desg)
            {
                Console.WriteLine($"{i.EmployeeID},{i.FirstName},{i.LastName},{i.Title},{i.DOJ.ToShortDateString()}.");
            }
            Console.WriteLine();
            //4.Display total number of employees

            Console.WriteLine($"{empList.Count}");
            Console.WriteLine();

            //5.Display total number of employees belonging to “Chennai”

            var chennai = empList.Count(e => e.City == "Chennai");
            Console.WriteLine(chennai);
            Console.WriteLine();

            //6.Display highest employee id from the list

            var highest = empList.Max(e => e.EmployeeID);
            Console.WriteLine(highest);
            Console.WriteLine();


            //7.Display total number of employee who have joined after 1 / 1 / 2015

            var empjoined = empList.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine(empjoined);
            Console.WriteLine();

            //8.Display total number of employee whose designation is not “Associate”

            var desgAssociate = empList.Count(e => e.Title != "Associate");
            Console.WriteLine(desgAssociate);

            //9.Display total number of employee based on City

            var noofemp = empList.GroupBy(e => e.City).Select(g => new { City = g.Key, Count = g.Count() });
            foreach (var i in noofemp)
            {
                Console.WriteLine($"{i.City}-{i.Count}");
            }
            Console.WriteLine();
            //10.Display total number of employee based on city and title

            var citytitle = empList.GroupBy(e => new { e.City, e.Title }).Select(f => new { f.Key.City, f.Key.Title, Count = f.Count() });
            foreach (var i in citytitle)
            {
                Console.WriteLine($"{i.City},{i.Title},{i.Count}");

            }
            Console.WriteLine();
            //11.Display total number of employee who is youngest in the list

            var young = empList.OrderByDescending(e => e.DOB).FirstOrDefault();
            if (young != null)
            {
                Console.WriteLine($"{young.FirstName} {young.LastName}");
            }
            Console.ReadLine();

        }
    }
}
