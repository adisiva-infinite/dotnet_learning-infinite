using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    class Product
    { 
    static void Main(string[] args)
    {
        List<Products> product_list = new List<Products>();
        Console.WriteLine("Enter Details of products");
        for (int i = 0; i <=9; i++)
        {
            Console.WriteLine($"Enter product : {i + 1}");
            Console.Write("Enter product Id : ");
            int prodid = int.Parse(Console.ReadLine());
            Console.Write("Enter the product Name : ");
            string prodname = Console.ReadLine();
            Console.Write("Enter the product price : ");
            float price = Convert.ToSingle(Console.ReadLine());
            product_list.Add(new Products(prodid, prodname, price));

        }
        product_list.Sort();

        Console.WriteLine("---------After sorting by price----------");
        foreach (Products p in product_list)
        {
            Console.WriteLine(p.ToString());
        }
        Console.ReadLine();
    }
    public class Products : IComparable<Products>
    {
        public int prod_id;
        public string product_name;
        public float price;

        public Products(int prod_id, string product_name, float price)
        {
            this.prod_id = prod_id;
            this.product_name = product_name;
            this.price = price;
        }

        public override string ToString()
        {
            return $"Product Name : {product_name}, product Id : {prod_id} , product price : {price}";
        }

        public int CompareTo(Products p)
        {
            return this.price.CompareTo(p.price);
        }

    }
  }
}
