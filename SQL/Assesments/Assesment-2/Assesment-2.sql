use Assignment2

-- SQL Assesment-2
select * from Emp

-- Write a query to display your birthday( day of week)
declare @Date_of_bday date = '11-Mar-2002'
select @Date_of_bday as 'Date of Birthday',DATENAME(weekday, @Date_of_bday) as 'Day of Week'

-- Write a query to display your age in days
declare @Age_in_days_Of_date date = '18-Mar-2002'
select datediff(day, @Age_in_days_Of_date, getdate()) as 'Age in Days'

-- Write a query to display all employees information those who joined before 5 years in the current month
select * from Emp where Hiredate <=DATEADD(year,-5,getdate()) and month(Hiredate)=month(getdate())

-- Create table Employee with empno, ename, sal, doj columns or use 
-- and perform the following operations in a single transaction

create table  Employee(
emp_no int primary key,
E_name varchar(50),
Sal float,
DOJ DATE
)

Begin transaction                                                                                 
insert into Employee values
(1,'Siva',6000,'11-Jun-2000'),
(2,'Likhitha',6300,'13-May-2009'),
(3,'Teja',6500,'18-mar-2020'),
(4,'Sai Ram',6900,'09-Jan-2000')


update Employee set Sal=Sal+(Sal*0.15) where emp_no = 2

delete from Employee where emp_no =1
rollback
commit
select * from Employee


--Create a user defined function calculate Bonus for all employees of a  given dept using 	following condition

create function Calculate_Bonus(@Dept_no int, @Salary float)
returns float
as
begin
    declare @bonus float;
    if @Dept_no = 10
        set @bonus = @Salary * 0.15;
 
    else if @Dept_no = 20
        set @bonus = @Salary * 0.20;
 
    else
        set @bonus = @Salary * 0.05;
 
   return @bonus;
end;

select dbo.Calculate_Bonus(30, 1000.00) as Bonus
select Emp_id, Ename,dbo.Calculate_Bonus(Dept_no,Salary) as Bonus from Emp


-- Create a procedure to update the salary of employee by 500 
-- whose dept name is Sales and current salary is below 1500 (use emp table)

create procedure  Update_salary_for_salesDepartments                   
  as
  begin
    update Emp
    set Salary= Salary+500
	where Dept_no=(select Dept_no from DEPT where Dept_name='sales') and Salary<1500
  end;
 
  Execute Update_salary_for_salesDepartments
  select *from Emp






