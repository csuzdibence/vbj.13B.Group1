using Students.Model;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EgyAHarmadikonAzEgy()
        {
            // AAA Arrange, Act, Assert
            Calculator calculator = new Calculator();

            var result = calculator.PowerBy(1, 3);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void KettoATizedikenAzEzerHuszonNegy()
        {
            // AAA Arrange, Act, Assert
            Calculator calculator = new Calculator();

            var result = calculator.PowerBy(2, 10);

            Assert.AreEqual(1024, result);
        }

        [Test]
        public void VbjNetEmailDomainValidTest()
        {
            // AAA Arrange, Act, Assert
            EmailDomainValidator validator = new EmailDomainValidator();
            Student student = new Student()
            {
                Id = 1,
                EmailAddress = "kissbela@vbjnet.hu",
            };
            var result = validator.ValidateStudent(student);

            Assert.IsTrue(result);
        }
    }
}