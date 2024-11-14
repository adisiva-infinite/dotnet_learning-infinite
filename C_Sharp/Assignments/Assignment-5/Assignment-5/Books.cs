using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    //  Create a class called Books with BookName and AuthorName as members.
    class Books
    {
        string Book_Name;
        string Author_Name;
        // Instantiate the class through constructor
        public Books(string Book_Name, string Author_Name)
        {
            this.Book_Name = Book_Name;
            this.Author_Name = Author_Name;
        }

        //  and also write a method Display() to display the details.
        public  void Display()
        {
            Console.WriteLine($"Title of the book is {Book_Name} and Authored by {Author_Name}");
        }
    }
    // Create an Indexer of Books Object to store 5 books in a class called BookShelf.
    class BookShelf
    {
        public Books[] Book_list = new Books[5];  // composition/aggregation 
        public Books this[int i]
        {
            get { return Book_list[i]; }
            set { Book_list[i] = value; }
        }

        // Using the indexer method assign values to the books and display the same.
        static void Main(string[] args)
        {
            Console.WriteLine("*** Enter the Books details***");
            Console.WriteLine();
            string Book_name;
            string Author_name;
            BookShelf bs = new BookShelf();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter book {i+1} details");
                Console.Write("Enter the book name : ");
                Book_name = Console.ReadLine();
                Console.Write("Enter book Author name : ");
                Author_name = Console.ReadLine();
                bs[i] = new Books(Book_name, Author_name);
            }

            Console.WriteLine();
            Console.WriteLine("*** Books Details ***");
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                bs[j].Display();
            }
            Console.ReadLine();

        }
    }
}
