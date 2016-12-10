using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnUnitTestFramework
{
    class Calculator
    {
        public int Add(int a, int b) 
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test(1, 1, 2);
            Test(2, 3, 5);
            Test(-2, -3, -5);
            Test(-2, -3, 5);
        }

        static void Test(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(a, b);

            // Assert
            Assert(expected, actual);
        }

        static void Assert(int expected, int actual)
        {
            var currentColor = Console.ForegroundColor;

            if (actual == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[TEST OK] ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[TEST FAILED] ");
            }

            Console.ForegroundColor = currentColor;

            Console.WriteLine("actual: {0}, expected {1}", actual, expected);
        }
    }
}
