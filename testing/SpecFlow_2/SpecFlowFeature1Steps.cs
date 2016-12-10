using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlow_2
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private int a, b;
        private Calculator calculator;

        [Given(@"I have entered (.*) an (.*) into the calculator")]
        public void GivenIHaveEnteredAnIntoTheCalculator(int p0, int p1)
        {
            a = p0;
            b = p1;
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            calculator = new Calculator();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expected)
        {
            var actual = calculator.Add(a, b);

            Assert.Equal(expected, actual);
        }
    }
}
