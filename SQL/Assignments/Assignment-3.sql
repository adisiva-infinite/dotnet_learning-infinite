use Assignment2

-- Assignment 3

select * from Emp

--Retrieve a list of MANAGERS.
select * from Emp where Job like 'Manager'

--Find out the names and salaries of all employees earning more than 1000 per month
select Ename,Salary from Emp where Salary>1000

--Display the names and salaries of all employees except JAMES. 
select Ename,Salary from Emp where Ename <> 'James'

--Find out the details of employees whose names begin with ‘S’
select * from Emp where Ename like 'S%'

--Find out the names of all employees that have ‘A’ anywhere in their name
select Ename from Emp where Ename like '%A%'

--Find out the names of all employees that have ‘L’ as their third character in their name
select Ename from Emp where Ename like '__L%'

--Compute daily salary of JONES
select Ename, (Salary/30) as 'Daily Salary' from Emp where Ename like 'Jones'

--Calculate the total monthly salary of all employees
select sum(Salary) as 'Total Monthly Salary for all Employees' from Emp

--Print the average annual salary
select avg(Salary*12) as 'Annual Salary' from Emp 

--Select the name, job, salary, department number of all employees except SALESMAN from department number 30
select Ename,Job,Salary,Dept_no from Emp where Job <> 'Salesman' and Dept_no <> 30

--List unique departments of the EMP table
select Distinct(Dept_no) from Emp

--List the name and salary of employees who earn more than 1500 and are in department 10 or 30.
--Label the columns Employee and Monthly Salary respectively
select Ename,Salary as 'Monthly salary' from Emp where Salary>1500 and Dept_no in (10,30)

--Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000
select Ename,Job,Salary from Emp where Job like 'Manager' or Job like 'Analyst' and Salary not in(1000,2000,3000)

--Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%
select Ename,Salary as 'Old Salary',(Salary*1.10) as 'Updated Salary' from Emp 

--Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782
select Ename,Dept_no from Emp where Ename like '%ll%' and Dept_no like 30 or Mgr_id like 7782

--Display the names of employees with experience of over 30 years and under 40 yrs
--Count the total number of employees
select Ename from Emp where datediff(year,Hiredate,getdate()) between 30 and 40
select count(Emp_id) as 'No of Employees' from Emp where datediff(year,Hiredate,getdate())between 30 and 40

--Retrieve the names of departments in ascending order and their employees in descending order
select Dept_name as 'Department Names sorted by A-Z' from DEPT order by Dept_name 
select Ename as'Employee Names sort Z-A' from Emp order by Ename desc

select d.Dept_name as 'Department Names sorted by A-Z',e.Ename as'Employee Names sort Z-A'
from DEPT d join Emp e on e.Dept_no=d.Dept_no order by d.Dept_name, e.Ename desc

--Find out experience of MILLER
select Ename,datediff(year,Hiredate,getdate()) as 'Experience' from Emp where ename='miller'
