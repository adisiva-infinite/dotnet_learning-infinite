create database Assesment_1
use Assesment_1

-- Write a query to fetch the details of the books written by author whose name ends with er.

select * from Books where Author like '%er'

-- Display the Title ,Author and ReviewerName for all the books from the above table

select b.Title,b.Author,r.reviewer_name from Books b join reviews r on b.Id = r.book_id

-- Display the  reviewer name who reviewed more than one book.
select reviewer_name from Reviews where book_id is not null group by reviewer_name
having count(distinct book_id)>1


-- Display the Names of the Employee in lower case, whose salary is null

select LOWER(Ename) from Employee where Salary is null 

--Display the Name for the customer from above customer table 
--who live in same address which has character o anywhere in 

select Ename from Employee where Addres like'%o%'

-- Write a sql server query to display the Gender,Total no of male and female from the above relation  

select Gender,count(*) as Total_count from Student_details group by Gender


-- Write a query to display the Date,Total no of customer  placed order on same Date

select date, count(CUSTOMER_ID) as TotalCustomers from Orders group by Date;


-- Creating table for Books

create table Books
(
Id int primary key,
Title varchar(30) not null,
Author varchar(20) not null,
Isbn float unique,
Published_date date,
)
-- inserting values into Books

insert into Books values
(1,'My First SQL book','Mary Parker',981483029127,'2019-02-22'),
(2,'My Second SQL book','John Maryer',857300923713,'1972-07-03'),
(3,'My Third SQL book','Cary Flint',523120967812,'2015-10-18')


-- creating table called reviews

create table Reviews
(
id int references Books(Id),
book_id int not null,
reviewer_name varchar(30) not null,
content varchar(30) not null,
rating int not null,
published_date date,
)

-- insert values to Reviews

insert into reviews values
(1,1,'John Smith','My first review',4,'2017-12-10'),
(2,2,'John Smith','My second review',5,'2017-10-13'),
(3,2,'Alice Walker','Another review',1,'2017-10-22')

select * from reviews


-- creating table called Student_details

create table Student_details
(
Register_no int primary key,
Name varchar(30) not null,
Age int not null,
Qualification varchar(20),
Mobile_no float not null,
Mail_id varchar(30),
locationn varchar(30),
Gender varchar(1)
)

-- inserting values into Student_details

insert into Student_details values
(2,'Sai',22,'B.E',9952836779,'sai@gmail,com','Chennai','M'),
(3,'Kumar',20,'BSC',7252836779,'kumar@gmail,com','Madurai','M'),
(4,'Selvi',22,'B.TECH',8952836779,'selvi@gmail,com','Selam','F'),
(5,'Nisha',25,'M.E',6352836779,'nisha@gmail,com','Theni','F'),
(6,'SaiSaran',21,'B.A',9865836779,'saisaran@gmail,com','Madurai','F'),
(7,'Tom',23,'BCA',6552836779,'tom@gmail,com','Pune','M')

select * from Student_details


-- creating table called Employee

create table Employee
(
Id int primary key,
Ename varchar(20) not null,
Age int not null,
Addres varchar(20) not null,
Salary int
)

-- inserting values into Employee

insert into Employee values
(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',null),
(7,'Muffy',24,'Indore',null)

select * from Employee

-- creating table called Customers

create table CUSTOMERS (
    ID int primary key,
    NAME varchar(20),
    AGE int,
    ADDRESS varchar(30),
    SALARY float
)

insert into CUSTOMERS values
(1,'Ramesh', 32, 'Ahmedabad', 2000.00),
(2,'Khilan', 25, 'Delhi', 1500.00),
(3,'Kaushik', 23, 'Kota', 2000.00),
(4,'Chaitali', 25, 'Mumbai', 6500.00),
(5,'Hardik', 27, 'Bhopal', 8500.00),
(6,'Komal', 22, 'MP', 4500.00),
(7,'Muffy', 24, 'Indore', 10000.00);
 
 
 -- creating table called ORDERS

create table ORDERS
( 
OID int, DATE varchar(20),
CUSTOMER_ID int, AMOUNT int, 
foreign key(CUSTOMER_ID) references CUSTOMERS(id)
)
 
insert into ORDERS values
(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560), 
(103,'2008-05-20 00:00:00',4,2060)

select * from ORDERS



