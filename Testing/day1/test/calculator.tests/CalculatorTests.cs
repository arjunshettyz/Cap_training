using Microsoft.VisualStudio.TestTools.UnitTesting;
using calc.Feature;

namespace calculator.tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Sum_AllCases()
        {
            var calculator = new Calculator();

            int result1 = calculator.Sum(1, 2, 3, 4, 5);
            Assert.AreEqual(15, result1);

            int result2 = calculator.Sum(4, 6);
            Assert.AreEqual(10, result2);

            int result3 = calculator.Sum(7);
            Assert.AreEqual(7, result3);

            int result4 = calculator.Sum();
            Assert.AreEqual(0, result4);
        }
    }
}
