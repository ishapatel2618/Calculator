using NUnit.Framework;

namespace Product.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_EmptyString()
        {
            int result = Calculator.Add("");

            Assert.AreEqual(0, result);
        }
        [TestCase("1",1)]
        [TestCase("2",2)]
        public void Add_OneNumberString(string numbers, int expected)
        {
            int result = Calculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }
        
        [TestCase("1,2",3)]
        [TestCase("2,3", 5)]
        public void Add_TwoNumbersString(string numbers, int expected)
        {
            int result = Calculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Add_MultipleNumbers()
        {
            int result = Calculator.Add("1,2,3");

            Assert.AreEqual(6,result);
        }
        [Test]
        public void Add_NoNumberStringWithelimeterLine()
        {
            int result = Calculator.Add("//,\n");

            Assert.AreEqual(0, result);
        }
        [Test]
        public void Add_OneNumberStringWithDelimeterLine()
        {
            int result = Calculator.Add("//,\n1");

            Assert.AreEqual(1, result);
        }
        [Test]
        public void Add_TwoNumberStringWithAlternativeDelimeter()
        {
            int result = Calculator.Add("//;\n1;2");

            Assert.AreEqual(3,result);
        }
    }
}
