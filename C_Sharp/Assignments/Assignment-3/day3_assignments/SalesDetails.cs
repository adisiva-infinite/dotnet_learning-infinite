using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{

    // Create a class called Saledetails
    // which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount

    class SalesDetails
    {
        public static int Sales_No;
        public static int Product_No;
        public static int Price;
        public static DateTime DateofSale;
        public static int Quantity;
        public static int TotalAmount;

        // Pass the other information like
        // SalesNo, Productno, Price,Qty and Dateof sale through constructor

        public SalesDetails(int sales_no, int product_no, int price, int qty, DateTime date_of_sale)
        {
            Sales_No = sales_no;
            Product_No = product_no;
            Price = price;
            Quantity = qty;
            DateofSale = date_of_sale;

        }

        // Create a method called Sales()
        // that takes qty, Price details of the object and updates the TotalAmount as  Qty *Price

        public void Sales(int price, int qty)
        {
            TotalAmount = qty * price;
        }
    }
    class SalesDetails1 : SalesDetails
    {
        public SalesDetails1(int sales_no, int product_no, int price, int qty, DateTime date_of_sale)
            : base(sales_no, product_no, price, qty, date_of_sale)
        {

        }

        // call the show data method to display the values without an object.
        public static void Show_Data()
        {
            Console.WriteLine(" ");
            Console.WriteLine("*** Total Bill ***");
            Console.WriteLine("Sales No: {0}", Sales_No);
            Console.WriteLine("Product No: {0}", Product_No);
            Console.WriteLine("Price : {0}", Price);
            Console.WriteLine("Quantity : {0}", Quantity);
            Console.WriteLine("Date of sale : {0}", DateofSale);
            Console.WriteLine("Total Amount : {0}", TotalAmount);
        }
        public static void Main()
        {
            Console.Write("Enter the Sales Number:");
            int sale_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Product Number:");
            int product_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Price:");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Date of sale:");
            DateTime dateofsale = Convert.ToDateTime(Console.ReadLine());
            SalesDetails Sdetails = new SalesDetails(sale_no, product_no, price, quantity, dateofsale);
            Sdetails.Sales(price, quantity);
            Show_Data();
            Console.Read();
        }
    }
}