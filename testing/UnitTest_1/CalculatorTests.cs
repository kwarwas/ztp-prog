using Xunit;

namespace UnitTest_1
{
    public class CalculatorTests
    {
        [Fact]
        public void Two_plus_two_should_give_four()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(2, 2);

            // Assert
            Assert.Equal(4, actual);
        }
    }
}
