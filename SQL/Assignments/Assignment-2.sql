create database Assignment2
use Assignment2
-- creating Department table
create table DEPT
(
Dept_no int primary key,
Dept_name varchar(20),
loc varchar(20)
)
select * from DEPT

-- inserting values to DEPT

insert into DEPT values
(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO'),
(40,'OPERATIONS','BOSTON')

select * from DEPT

-- creating table for Employeee

create table Emp
(
Emp_id int primary key,
Ename varchar(20) not null,
Job varchar(20) not null,
Mgr_id int,
Hiredate date not null,
Salary float,
Com int,
Dept_no int references DEPT(Dept_no)
)

-- inserting employee details

insert into Emp values
(7369,'SMITH','CLERK',7902,'17-DEC-80',800,null, 20),
(7499,'ALLEN','SALESMAN',7698,'20-FEB-81',1600,300,30),
(7521,'WARD','SALESMAN',7698,'22-FEB-81',1250,null,30),
(7566,'JONES','MANAGER',7839,'02-APR-81', 2975,null,20),
(7654,'MARTIN','SALESMAN',7698,'28-SEP-81',1250, 1400,30),
(7698,'BLAKE','MANAGER',7839,'01-MAY-81',2850,null,30),
(7782,'CLARK','MANAGER',7839,'09-JUN-81',2450,null,10),
(7788,'SCOTT','ANALYST',7566,'19-APR-87',3000,null,20),
(7839,'KING','PRESIDENT',null,'17-NOV-81',5000,null,10),
(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
(7900,'JAMES','CLERK',7698,'03-DEC-81',950,null,30),
(7902,'FORD','ANALYST',7566,'03-DEC-81',3000,null,20),
(7934,'MILLER','CLERK',7782, '23-JAN-82',1300,null,10)

select * from DEPT
select * from Emp
sp_help DEPT

-- List all employees whose name begins with 'A'

select * from Emp where Ename like 'A%'

-- Select all those employees who don't have a manager. 

select * from Emp where Mgr_id is null

-- List employee name, number and salary for those employees who earn in the range 1200 to 1400. 

select Ename,Emp_id,Salary,* from Emp where Salary>=1200 and Salary<=1400

-- Give all the employees in the RESEARCH department a 10% pay rise. 
-- Verify that this has been done by listing all their details before and after the rise. 

select *,Salary as 'Before salary',Salary+((Salary*10)/100) as 'After Salary' from Emp where Dept_no = 20

-- Find the number of CLERKS employed. Give it a descriptive heading. 

select COUNT('Job') as 'Clerks' from Emp where Job = 'Clerk'

-- Find the average salary for each job type and the number of people employed in each job. 

select Job,avg(Salary) as 'Average Salary', count(*) as 'Emp Count' from Emp group by Job

-- List the employees with the lowest and highest salary. 

select Ename,Salary from Emp where Salary =(select min(Salary) from Emp)
select Ename,Salary from Emp where Salary=(select max(Salary) from Emp)

-- List full details of departments that don't have any employees. 

select d.Dept_name from DEPT d left join Emp e on d.Dept_no=e.Dept_no where e.Dept_no IS NULL

-- Get the names and salaries of all the analysts earning more than 1200 who are based in department 20.
-- Sort the answer by ascending order of name. 

select * from Emp where Job ='Analyst' and Salary>1200 and Dept_no=20

--  For each department, list its name and number together with the total salary paid to employees in that department. 

select e.Ename,e.Salary,e.Dept_no,sum(e.Salary) as Total_Salary
from Emp e join Emp e1
on e.Dept_no=e1.Dept_no
group by e.Ename,e.Salary,e.Dept_no

--  Find out salary of both MILLER and SMITH.

select Ename,Salary from Emp where Ename in ('Miller','Smith')

--  Find out the names of the employees whose name begin with ‘A’ or ‘M’. 

select Ename from Emp where Ename like 'A%' and Ename like '%M'

--  Compute yearly salary of SMITH. 

select Salary*12 as Annual_salary from Emp where Ename = 'SMITH'

--  List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 

select Ename,Salary from Emp where Salary between 1500 and 2850
select Ename,Salary from Emp where Salary>=1500 and Salary<=2850

-- Find all managers who have more than 2 employees reporting to them

select Mgr_id,count(*) as Employee_Count from Emp group by Mgr_id having count(*)>2