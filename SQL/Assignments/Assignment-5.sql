use Assignment2

-- Assignment -5
-- Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

create or alter proc PaySlip(@EmpId int)
as
begin
declare @Ename varchar(20),@Sal int
declare @HRA float
declare @DA float
declare @PF float
declare @IT float
declare @Deduction float
declare @Gross_Salary float
declare @Net_Salary float
select @Ename=EName,@Sal=Salary from Emp where Emp_id=@EmpId

-- HRA as 10% of Salary
set @HRA=@sal*0.10

-- DA as 20% of Salary
set @DA=@sal*0.20

--  PF as 8% of Salary
set @PF=@sal*0.08

-- IT as 5% of Salary
set @IT=@sal*0.05

--Deductions as sum of PF and IT
set @Deduction=@PF+@IT

-- Gross Salary as sum of Salary, HRA, DA
set @Gross_Salary=@sal+@HRA+@DA

--Net Salary as Gross Salary - Deductions
set @Net_Salary=@Gross_Salary-@Deduction
print 'Payslip for Employee : ' +@Ename
print 'Basic Salary : '+cast(@Sal as varchar(10))
print 'HRA : ' +cast(@HRA as varchar(10))
print 'DA : ' +cast(@DA as varchar(10))
print 'PF : ' +cast(@PF as varchar(10))
print 'IT : ' +cast(@IT as varchar(10))
print 'Deduction : ' +cast(@Deduction as varchar(10))
print 'Gross salary : ' +cast(@Gross_Salary as varchar(10))
print 'Net salary : ' +cast(@Net_Salary as varchar(10))
end
exec PaySlip 7369


-- Create a trigger to restrict data manipulation on EMP table during General holidays. Display 
-- the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc

CREATE TABLE Holidays (
    holiday_date DATE PRIMARY KEY,
    holiday_name VARCHAR(20) NOT NULL
);
INSERT INTO Holidays (holiday_date, holiday_name) VALUES
('2024-01-26', 'Republic Day'),
('2024-03-29', 'Holi'),
('2024-08-15', 'Independence Day'),
('2024-11-12', 'Diwali');
insert into holidays values('2024-12-06','Holiday');
CREATE or alter TRIGGER RestrictManipulationOnHolidays
ON Emp
for insert,update,delete
as
BEGIN
    declare @holiday_name VARCHAR(20);
	declare @current_date date = cast(getdate() as date)
    select @holiday_name =holiday_name
    from Holidays
    where holiday_date = @current_date;
    if @holiday_name IS NOT NULL
	begin
        raiserror('Data manipulation is restricted due to %s',16,1, @holiday_name)
		rollback transaction
    END 
END
update Emp set Salary=1000 where Emp_id=7788
select * from Emp
