using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    class EmployeeTarget
    {
        public IEmployee E1 = null; // E1 is object for IEmployee Interface
        public EmployeeTarget(EmployeeDependent employee) // Constructor Injection and i pass
                                                          // parameter as Employee dependent cls with obj
        {
            this.E1 = employee; // initially e1 have null so we have created a constructor
                                // with employeedependent obj to E1
        }
        public List<Employee> GetEmployees() // creating method return employee data 
        {
            return E1.getEmployeeData(); // E1 having EmployeeDependent and calls getemployeedata
        }
    }
}
