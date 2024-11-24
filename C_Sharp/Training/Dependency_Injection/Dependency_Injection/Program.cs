using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating obj for Employee Target and pass parameter as Employee Dependent class...

            EmployeeTarget ET = new EmployeeTarget(new EmployeeDependent());
            List<Employee> employees = ET.GetEmployees();

            foreach (Employee E1 in employees)
            {
                Console.WriteLine(E1.Employee_Id + " " + E1.Emp_Name + " " + E1.Salary);
            }
            Console.Read();
        }
    }
}
