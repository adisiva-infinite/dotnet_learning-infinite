using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Doctor
    {
        // Create a Class called Doctor with RegnNo, Name, Feescharged as Private members.
        // Create properties to give values and also to display the same.

        int reg_No;
        string name;
        double fees_charged;
        public int Reg_No
        {
            get { return reg_No;}
            set { reg_No = value; }
        }

        public string Name
        {
            get { return name;}
            set { name = value; }

        }
        public double Fees_charged
        {
            get { return fees_charged;}
            set { fees_charged = value;}
        }

    }
    class Books
    {
        string Book_Name;
        string Author_Name;
        public Books(string book_name, string author_name)
        {
            Book_Name = book_name;
            Author_Name = author_name;

        }
        public void Display()
        {
            Console.WriteLine("Book name is {0} and Author name is {1}", Book_Name,Author_Name);
        }
    }
    class Bookshelf
    {
        Books[] b = new Books[5];
        public Books this[int pos]
        {
            get { return b[pos];}
            set { b[pos] = value;}
        }
    }
    class Driver
    {
        public static void Main()
        {
            Console.WriteLine(" *** Enter Doctor details ***");
            Console.WriteLine();
            Console.Write("Enter the Registred number : ");
            int regnum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Name : ");
            string Namee = Console.ReadLine();
            Console.Write("the amoubnt of fee charged is : ");
            double fees = Convert.ToDouble(Console.ReadLine());
            Doctor d = new Doctor();
            Console.WriteLine();

            Console.WriteLine(" *** Doctor Details ***");
            d.Reg_No = regnum;
            Console.WriteLine("Registration number : {0}", d.Reg_No);
            d.Name = Namee;
            Console.WriteLine("Name : {0}", d.Name);
            d.Fees_charged = fees;
            Console.WriteLine("fees chaged is : {0}", d.Fees_charged);

            // Book details
            Console.WriteLine();
            Console.WriteLine(" *** Enter Book Details ***");
            Console.Write("Enter Book name : ");
            string bname = Console.ReadLine();
            Console.Write("Enter author name : ");
            string aname = Console.ReadLine();
            Books b = new Books(bname, aname);
            Console.WriteLine();
            Console.WriteLine("*** Book details ***");
            b.Display();

            // BookShelf
            Console.WriteLine();
            Console.WriteLine(" ----- Using indexers ----");
            Bookshelf book_shelf = new Bookshelf();
            Console.WriteLine("Book details");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("enter Book name : ", i + 1);
                string bookname = Console.ReadLine();
                Console.Write("enter author name :", i + 1);
                string authorname = Console.ReadLine();
                book_shelf[i] = new Books(bookname, authorname);
            }
            Console.WriteLine(" ");
            Console.WriteLine("*** Book details as follows ***");
            for (int j = 0; j <= 5; j++)
            {
                book_shelf[j].Display();
            }
            Console.Read();
        }

    }
}