using Moq;

namespace UnitTest.Practice
{
    public class CalculatorTests
    {
        // Osztály amit tesztelünk
        private Calculator calculator;

        // Mockok
        private Mock<IAdder> adderMock;

        /// <summary>
        /// Minden egyes teszt elõtt lefut
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Arrange
            adderMock = new Mock<IAdder>();
            calculator = new Calculator(adderMock.Object);
        }

        [Test]
        public void TestThatAdding1To2NotEqualsTo0()
        {
            // Arrange
            adderMock.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(3);

            // Act
            int result = calculator.Add(1, 2);

            // Verify (egy fajta assert)
            // Meg lett hívva-e egy egzakt metódus (pontosan valahányszor)
            adderMock.Verify(x => x.Add(1, 2), Times.Once);

            // Assert
            Assert.AreEqual(3, result);
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
        public void TestMinReturnsMinimumValue1()
        {
            // Arrange (Input)
            int[] nums = new int[] { 5, 15, 1, -5, 26, 3, 89, -150, 55, 67, 88, 23, 100};
            // Act -> Output
            int result = calculator.Min(nums);
            // Assert -> Input == Output ??
            Assert.AreEqual(-150, result);
        }

        [Test]
        public void TestMinReturnsMinimumValue2()
        {
            int[] nums = new int[] { 4, 8, 16, 24, 1, -2, 3};
            int result = calculator.Min(nums);
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void TestMinReturnsNotTheSecondMinimumValue3()
        {
            int[] nums = new int[] { 4, 8, 16, 24, 1, -2, 3 };
            int result = calculator.Min(nums);
            Assert.AreNotEqual(1, result);
        }
    }
}