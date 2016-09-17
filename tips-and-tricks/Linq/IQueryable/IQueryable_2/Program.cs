using IQueryable_2.EF;
using System;
using System.Linq;

namespace IQueryable_2
{
    public enum CustomerType
    {
        Normal,
        Silver,
        Gold
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindContext())
            {
                context.Database.Log = Console.WriteLine;

                var customerTypes = context.Customers
                    .Where(x => x.Orders.Any())
                    .Select(x => new
                    {
                        x.CustomerID,
                        Price = x.Orders.Sum(y => y.Order_Details.Sum(z => (1 - z.Discount) * z.Quantity * (float)z.UnitPrice))
                    })
                    .Select(x => new
                    {
                        x.CustomerID,
                        x.Price,
                        CustomerType = x.Price > 100000 ? CustomerType.Gold : x.Price > 10000 ? CustomerType.Silver : CustomerType.Normal
                    })
                    .GroupBy(x => x.CustomerType);

                foreach (var type in customerTypes)
                {
                    Console.WriteLine(type.Key);

                    foreach (var item in type)
                    {
                        Console.WriteLine($"{item.CustomerID} {item.Price} {item.CustomerType}");
                    }
                }
            }
        }
    }
}
