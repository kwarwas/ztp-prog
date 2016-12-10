using Xunit;

namespace UnitTest_2
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 5)]
        [InlineData(-1, -1, -2)]
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
