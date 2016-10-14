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

                context.Database.Log = Console.WriteLine;

                var products = context.Products
                    .ToArray()
                    .OrderBy(x => Guid.NewGuid())
                    .Take(3)
                    .Select(x => x.ProductName);

                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                foreach (var item in products)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
