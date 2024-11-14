using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Employee
    {
        public int EmpId;
        public string EmpName;
        public float Salary;
        public Employee(int eid, string ename, float sal)
        {
            EmpId = eid;
            EmpName = ename;
            Salary = sal;
        }
        public void Display()
        {
            Console.WriteLine("Id of Enployee is {0} and name is {1} and his (or) her salary is {2}", EmpId, EmpName, Salary);
        }
    }

    class partTimeEmployee : Employee
    {
        int Wages;
        public partTimeEmployee(int eid, string ename, float sal) : base(eid, ename, sal)
        {

        }
        public static void Main()
        {
            Console.Write("Enter employye id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter salary of employee : ");
            float salaryy = (float)Convert.ToInt32(Console.ReadLine());
            //Console.Write("Employee class constructor : ");
            //Employee E1 = new Employee(id, name, salaryy);
            //E1.Display();
            partTimeEmployee p1 = new partTimeEmployee(id, name, salaryy);
            p1.Display();
            Console.Read();
        }
    }
}