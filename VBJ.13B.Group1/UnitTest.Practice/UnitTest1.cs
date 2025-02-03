namespace UnitTest.Practice
{
    public class Tests
    {
        private Calculator calculator;

        /// <summary>
        /// Minden egyes teszt elõtt lefut
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Arrange
            calculator = new Calculator();
        }

        [TestCase(1, 1, 2)]
        [TestCase(-50, 40, -10)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, -1, -2)]
        public void TestAddingIsWorkingRight(int a, int b, int result)
        {
            int addResult = calculator.Add(a, b);
            Assert.AreEqual(addResult, result);
        }

        /// <summary>
        /// Ez a teszt a hatványozást teszteli
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        [TestCase(1.0, 0, 1.0)]
        [TestCase(0.0, 16, 0.0)]
        [TestCase(1.5, 2, 2.25)]
        [TestCase(-1.0, 2, 1.0)]
        public void TestPowerByIsWorkingRight(double a, int b, double result)
        {
            double powerByResult = calculator.PowerBy(a, b);
            Assert.AreEqual(powerByResult, result);
        }

        [Test]
        public void TestThatAdding1To2NotEqualsTo0()
        {
            // Act
            int result = calculator.Add(1, 2);
            // Assert
            Assert.AreNotEqual(0, result);
        }
    }
}