use Assesment_1

-- Assesment -3

create table Coursedetails
(
C_id varchar(20),
C_Name varchar(20),
Startt_date date,
End_date date,
Fee float
)

insert into Coursedetails values
('DN003','DotNet','2018-02-01','2018-02-28',15000),
('DV004','DataVisualization','2018-03-01','2018-04-15',15000),
('JA002','AdvancedJava','2018-01-02','2018-01-20',10000),
('JC001','CoreJava','2018-01-02','2018-01-12',3000)

select * from Coursedetails
drop table Coursedetails
--Create a Function to calculate the course duration for the above relation by receiving start date and end date as input.

create function Course_Duration
(
@start_date date,
@end_date date
)
returns int
as
begin
return Datediff(day,@start_Date,@end_date)  
end;

select C_id,C_Name,dbo.Course_Duration(Startt_date,End_date) as 'Duration in days' from Coursedetails


--Create a trigger to display the Course Name and Start date of the course

create table Courseinfo
(
C_Name varchar(20),
Startt_Date Date
)

--2.creating a trigger which modifies in t_CourseInfo
create trigger Update_course_info   
on CourseDetails
after insert
as
begin
insert into Courseinfo(C_Name,Startt_Date)
select C_Name,Startt_Date from inserted;
end
 
insert into CourseDetails values('AS06','Web','2018-03-16','2019-01-8',9000)  
select * from Courseinfo


--Write a stored Procedure that inserts records in the ProductsDetails table

create table ProductsDetails
(
Product_id int identity(1,1),
Product_Name varchar(30),
Price float,
Discount_Price as (Price * 0.10)
)

create procedure sp_productdetails
@Product_Id int,
@Product_name varchar(30),
@Price float,
@Discount_price float
as
Begin 
insert into ProductsDetails(Product_Name, Price)values(@Product_name, @Price);
set @Product_Id=SCOPE_IDENTITY();
end
 
 
select * from ProductsDetails;