using IQueryable_3.EF;
using System;
using System.Linq;

namespace IQueryable_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindContext())
            {
                context.Database.Log = Console.WriteLine;

                var query_1 = context.Categories
                    ;//.Include("Products");

                foreach (var category in query_1)
                {
                    Console.WriteLine($"{category.CategoryName} - {category.Products.Count()}");

                    Console.WriteLine("-- PRODUKTY --");

                    foreach (var product in category.Products)
                    {
                        Console.WriteLine($" - {product.ProductName}");
                    }

                    Console.WriteLine("-- KONIEC --");
                }

                //var query_2 = context.Products;

                //foreach (var product in query_2)
                //{
                //    Console.WriteLine($"{product.ProductName} - {product.Category?.CategoryName}");
                //}
            }
        }
    }
}
