using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitTest_3
{
    public class CalculatorTests
    {
        public static object[][] data = 
        {
            new object[] {1, 2, 3},
            new object[] {2, 3, 5},
            new object[] {-1, -1, -2},
        };

        [Theory]
        [MemberData(nameof(data))]
        public void A_plus_b_should_give_c(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
