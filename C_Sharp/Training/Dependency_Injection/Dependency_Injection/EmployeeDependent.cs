using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public interface IEmployee  // Creating IEmployee interface for Passing Data
    {
        List<Employee> getEmployeeData(); // Creating Abstract method by default public 
    }
    class EmployeeDependent : IEmployee
    {
        public List<Employee> getEmployeeData()
        {
            List<Employee> Emp = new List<Employee>() // declaration of list and Employee is return type
                                                      // in Employee we declared data members like
                                                      // emp id , em name and emp salary...
            {
               new Employee{Employee_Id = 11, Emp_Name = "Adi Siva Naidu" , Salary=21000},
               new Employee {Employee_Id=12,Emp_Name="Bhanu",Salary=21500}
            };
            return Emp;
        }
    }
}
