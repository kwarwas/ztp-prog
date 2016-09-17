using IQueryable_1.EF;
using System;
using System.Linq;

namespace IQueryable_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            using (var context = new NorthwindContext())
            {
                // TODO: Wyświetlić trzy nazwy losowych produktów

                var products = context.Products
                    //???
                    .Take(3);

                foreach (var item in products)
                {
                    Console.WriteLine(item.ProductName);
                }

                Console.WriteLine();

                foreach (var item in products)
                {
                    Console.WriteLine(item.ProductName);
                }
            }
        }
    }
}
