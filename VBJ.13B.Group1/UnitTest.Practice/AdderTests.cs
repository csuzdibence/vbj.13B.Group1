using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Practice
{
    internal class AdderTests
    {
        private Adder adder;

        [SetUp]
        public void Setup()
        {
            adder = new Adder();
        }

        [TestCase(1, 1, 2)]
        [TestCase(-50, 40, -10)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, -1, -2)]
        public void TestAddingIsWorkingRight(int a, int b, int result)
        {
            int addResult = adder.Add(a, b);
            Assert.AreEqual(addResult, result);
        }

        [Test]
        public void TestThatAdding1To2NotEqualsTo0()
        {
            // Act
            int result = adder.Add(1, 2);
            // Assert
            Assert.AreNotEqual(0, result);
        }
    }
}
