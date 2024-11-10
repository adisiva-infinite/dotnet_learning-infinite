using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable
{
    class Comparable_And_Comparer
    {
        static void Main(string[] args)
        {
            List<Employee> emplist = new List<Employee>
            {
                new Employee(200, "Nikhil", 50000, "Infinite"),
                new Employee(130, "Navya", 52000, "Infinite"),
                new Employee(250, "Sahana", 48000, "Infinite"),
                new Employee(150, "Rajesh", 50000, "Infinite")
            };

            Console.WriteLine("---------Before sorting----------");
            foreach (Employee e in emplist)
            {
                Console.WriteLine(e.ToString());
            }

            // Sort the list by EmpId
            emplist.Sort();

            Console.WriteLine("---------After sorting by EmpId----------");
            foreach (Employee e in emplist)
            {
                Console.WriteLine(e.ToString());
            }
            Console.Read();
        }
    }

    class Employee : IComparable<Employee>
    {
        int EmpId;
        string EmpName;
        public float Salary;
        string Company;

        public Employee(int id, string name, float sal, string comp)
        {
            EmpId = id;
            EmpName = name;
            Salary = sal;
            Company = comp;
        }

        public override string ToString()
        {
            return $"Employee Named : {EmpName} with Id : {EmpId} Works for {Company} and Earns Rs. : {Salary}";
        }


        public int CompareTo(Employee anotherobj)
        {
            return this.EmpId.CompareTo(anotherobj.EmpId);
        }
    }
}