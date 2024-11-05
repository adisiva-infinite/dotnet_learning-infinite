using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day3_assignments
{
    // Create a class called Accounts which has data members/fields like
    // Account no, Customer name, Account type, Transaction type (d/w), amount, balance

    class Accounts
    {
            public string Customer_name;
            public int Account_No;
            public string Account_type;
            public string Transaction_type;
            public int Money;
            public int Balance = 10000;
            public string Check;

        public Accounts(string customer_name, int account_no, string account_type)
        {
            Customer_name = customer_name;
            Account_No = account_no;
            Account_type = account_type;
        }
        public void CustomerDetails()
            {
            Console.Write("Type of Transaction : ");
            Transaction_type = Console.ReadLine();           
        }
            public void Show_data()
            {
                Console.WriteLine(" ");
                Console.WriteLine("*** Customer Details ***");
                Console.WriteLine("Customer name : {0} ", Customer_name);
                Console.WriteLine("Account number : {0} ", Account_No);
                Console.WriteLine("Account type : {0} ", Account_type);
            }
        public void Type_of_Transaction()
        {
            switch (Transaction_type)
            {
                case "Deposit":
                case "deposit":
                    Console.Write("Amount : ");
                    Money = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Deposit Amount is :" + Money);
                    Deposit_Amount();
                    break;
                case "Withdraw":
                case "withdraw":
                    Console.Write("Amount : ");
                    Money = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Withdraw Amount is :"+ Money);
                    Withdraw_Amount();
                    break;
                case "Check Balance":
                case "check balance":
                    Total_Balance();
                    break;
                default:
                    Console.WriteLine("Invalid Statement");
                    break;
            }
        }
        public void Deposit_Amount()
        {
            Console.WriteLine(" ");
            Console.WriteLine("*** Payment Details ***");
            Console.WriteLine("In your A/c Sucessfully Credited {0}/-", Money);
            Check_Balance();
        }
        public void Withdraw_Amount()
        {
            Console.WriteLine(" ");
            Console.WriteLine("*** Payment Details ***");
            if (Money < Balance)
            {
                Console.WriteLine("In your A/c Withdraw Amount is {0}/-",Money);
                Check_Balance();
            }
            else Console.WriteLine("Insufficent funds in Account");
        }

        public void Check_Balance()
        {
            Console.WriteLine(" ");
            Console.Write("If you want see your Account balance : ");
            Check = Console.ReadLine();

            switch(Check)
            {
                case "Yes":
                case "yes":
                    Total_Balance();
                    break;
                case "No":
                case "no":
                    Exit();
                    break;
            }
        }
        public void Total_Balance()
        {
            Console.WriteLine("*** Total balance ***");

            switch (Transaction_type)
            {
                case "Deposit":
                case "deposit":
                    Console.WriteLine("Available balance is :" + (Balance = Balance + Money) +"/-");
                    break;
                case "Withdraw":
                case "withdraw":
                    Console.WriteLine("Available balance is :" + (Balance = Balance - Money) + "/-");
                    break;
                case "Check Balance":
                case "check balance":
                    Console.WriteLine("Available balance is :" + Balance + "/-");
                    break;
            }
        }

        public void Exit()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Thank you!");
        }
        static void Main()
        {
            Console.Write("Enter Customer name : ");
            string Customer_name = Console.ReadLine();
            Console.Write("Enter Account number : ");
            int Account_No = Convert.ToInt32(Console.ReadLine());
            Console.Write("Type of Account : ");
            string Account_type = Console.ReadLine();
            Accounts Ac = new Accounts(Customer_name,Account_No,Account_type) ;
            Ac.CustomerDetails();
            Ac.Show_data();
            Ac.Type_of_Transaction();
            Console.ReadLine();
        }
    }

}
