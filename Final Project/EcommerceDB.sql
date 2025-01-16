create database Ecommerce
use Ecommerce

-- Customers Table
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(50) NOT NULL,
    EmailAddress VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(20) NOT NULL,
    DeliveryAddress VARCHAR(20),
	MobileNumber VARCHAR(12) NOT NULL
);
 
-- Categories Table
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(30) NOT NULL,
    Description VARCHAR(100),
    ProductImage VARCHAR(255) -- To store the URL or file path of the category image
);

-- Products Table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
	ProductName VARCHAR(30) NOT NULL,
    CategoryId INT REFERENCES Categories(CategoryId),
    ModelNumber VARCHAR(12) NOT NULL,
    ModelName VARCHAR(20) NOT NULL,
    UnitCost FLOAT NOT NULL,
    Description VARCHAR(30),
    ProductImage VARCHAR(255), -- To store the URL or file path of the product image
	Stock INT NOT NULL
);
 
-- Orders Table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT REFERENCES Customers(CustomerId),
    OrderDate DATE NOT NULL,
    ShipDate DATE
);
 
-- OrderDetails Table
CREATE TABLE OrderDetails (
    OrderDetailId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT REFERENCES Orders(OrderId),
	CustomerId INT REFERENCES Customers(CustomerId),
    ProductId INT REFERENCES Products(ProductId),
    Quantity INT NOT NULL,
    UnitCost FLOAT NOT NULL
);
 
-- ShoppingCart Table

CREATE TABLE ShoppingCart (
    RecordId INT PRIMARY KEY IDENTITY(1,1),
    CartId UNIQUEIDENTIFIER NOT NULL,
	Customerid int REFERENCES Customers(CustomerId),
    ProductId INT REFERENCES Products(ProductId),
    Quantity INT NOT NULL,
    DateCreated DATETIME DEFAULT GETDATE()
);

--admin table
CREATE TABLE Admins
(
Admin_Id INT PRIMARY KEY IDENTITY(1,1),
Email_Address VARCHAR(30),
Password VARCHAR(20) not null
)

insert into Admins values
('Admin@gmail.com','Admin123')

insert into Categories values
('Home Decor', 'Sofa, Book Shelf, Lamp','https://www.whiteteak.com/media/catalog/category/Category_home_decor_mobile_1_.jpg'),
('Fashion', 'Men, Women, Kids','https://audaces.com/wp-content/uploads/2020/08/fashion-styles.webp'),
('Mobiles', 'All types of Mobiles','https://www.reliancedigital.in/wp-content/uploads/2022/03/cover_new_mobiles.jpg'),
('Laptops', 'Hp, Dell, Mi','https://dlcdnrog.asus.com/rog/media/1735949598774.webp'),
('Groceries', 'Dry Fruits, Beverages','https://images.stockcake.com/public/9/a/b/9ab8b46e-b652-4e61-9198-41e8aa87e92d_large/grocery-shelf-array-stockcake.jpg'),
('Beauty & Personal care', 'Face care, Hair care, Body care','https://5.imimg.com/data5/SELLER/Default/2021/3/IY/FP/EU/93396377/personal-care-products-500x500.jpg'),
('Foot Wear','Men & and Women', 'https://images.unsplash.com/photo-1529810313688-44ea1c2d81d3'),
('Stationary','Books, Pens','https://images.unsplash.com/photo-1600926565634-ff972dfb33a3')


select * from Customers
select * from Categories
select * from Products
select * from Orders
select * from OrderDetails
select * from ShoppingCart
select * from Admins


drop database Ecommerce
