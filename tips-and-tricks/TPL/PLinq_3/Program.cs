using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.IO;
using System.Linq;

namespace PLinq_3
{
    class EmployeeRecord
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime HireDate { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var textReader = new StreamReader("employees.csv"))
            {
                using (var csv = new CsvReader(textReader, new CsvConfiguration { HasHeaderRecord = false }))
                {
                    var records = csv.GetRecords<EmployeeRecord>().ToArray();

                    var men = records
                        .AsParallel()
                        .Where(x => x.Id > 10010);

                    foreach (var item in men.Take(1000))
                    {
                        Console.WriteLine($"{item.Id} {item.LastName}");
                    }
                }
            }
        }
    }
}
