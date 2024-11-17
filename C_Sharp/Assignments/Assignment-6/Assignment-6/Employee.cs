using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCity { get; set; }
        public double EmployeeSalary { get; set; }

    }
    class Employee1
    {
        static void Main()
        {
            Console.Write("Enter List length : ");
            int list_length = Convert.ToInt32(Console.ReadLine());
            List<Employee> employee_list = new List<Employee> { };
            for (int i = 0; i < list_length; i++)
            {
                Console.Write($"Enter Employe ID of {i + 1} : ");
                int Employee_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employe Name : ");
                string Employee_name = Console.ReadLine();
                Console.Write("Enter Employe City : ");
                string Employee_city = Console.ReadLine();
                Console.Write("Enter Employe Salary : ");
                double Employee_salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                employee_list.Add(new Employee
                {
                    EmployeeID = Employee_id,
                    EmployeeName = Employee_name,
                    EmployeeCity = Employee_city,
                    EmployeeSalary = Employee_salary
                });
            }
            Console.WriteLine();
            Console.WriteLine("***  Details of All employees  ***");
            foreach (var All in employee_list)
            {
                Console.WriteLine($"Emp_id : {All.EmployeeID} Name : {All.EmployeeName} from {All.EmployeeCity} Salary : {All.EmployeeSalary}/- ");
            }
            Console.WriteLine();

            Console.WriteLine("***  Employees whose salary is greater than 45000  ***");
            foreach (var emp in employee_list) if (emp.EmployeeSalary > 45000) Console.WriteLine(emp.EmployeeName);
            Console.WriteLine();

            Console.WriteLine("***  Employees data who belong to Bangalore Region are  ***");
            foreach (var emp in employee_list)
            {
                if (emp.EmployeeCity == "Bangalore" || emp.EmployeeCity == "bangalore")
                    Console.WriteLine($"{ emp.EmployeeName}  from { emp.EmployeeCity}");
            }
            Console.WriteLine();

            IEnumerable<Employee> Ascendingorder = employee_list.OrderBy(n => n.EmployeeName);
            Console.WriteLine("***  Employees data by their names is Ascending order  ***");

            foreach (var emp in Ascendingorder)
            {
                Console.WriteLine(emp.EmployeeName);
            }
            Console.ReadLine();
        }
    }
}
