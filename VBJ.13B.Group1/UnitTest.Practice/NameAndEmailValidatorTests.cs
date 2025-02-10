using Moq;
using Students.Model;

namespace UnitTest.Practice
{
    internal class NameAndEmailValidatorTests
    {
        private NameAndEmailValidator nameAndEmailValidator;

        private Mock<INameLengthValidator> nameValidatorMock;
        private Mock<IEmailDomainValidator> emailValidatorMock;

        [SetUp]
        public void Setup()
        {
            nameValidatorMock = new Mock<INameLengthValidator>();
            emailValidatorMock = new Mock<IEmailDomainValidator>();

            nameAndEmailValidator = new NameAndEmailValidator(nameValidatorMock.Object, emailValidatorMock.Object);
        }

        [Test]
        public void IfNameIsRightAndEmailIsNotRightReturnFalse()
        {
            nameValidatorMock.Setup(x => x.ValidateStudent(It.IsAny<Student>())).Returns(true);
            emailValidatorMock.Setup(x => x.ValidateStudent(It.IsAny<Student>())).Returns(false);

            bool result = nameAndEmailValidator.ValidateStudent(new Student());

            nameValidatorMock.Verify(x => x.ValidateStudent(It.IsAny<Student>()), Times.Once);
            emailValidatorMock.Verify(x => x.ValidateStudent(It.IsAny<Student>()), Times.Once);

            Assert.IsFalse(result);
        }

        [Test]
        public void IfNameIsIncorrectAndEmailIsCorrectReturnFalse()
        {
            nameValidatorMock.Setup(x => x.ValidateStudent(It.IsAny<Student>())).Returns(false);
            emailValidatorMock.Setup(x => x.ValidateStudent(It.IsAny<Student>())).Returns(true);

            bool result = nameAndEmailValidator.ValidateStudent(new Student());

            nameValidatorMock.Verify(x => x.ValidateStudent(It.IsAny<Student>()), Times.Once);
            emailValidatorMock.Verify(x => x.ValidateStudent(It.IsAny<Student>()), Times.Never);

            Assert.IsFalse(result);
        }

        [Test]
        public void IfNameIsCorrectAndEmailIsCorrectReturnTrue()
        {
            nameValidatorMock.Setup(x => x.ValidateStudent(It.IsAny<Student>())).Returns(true);
            emailValidatorMock.Setup(x => x.ValidateStudent(It.IsAny<Student>())).Returns(true);

            bool result = nameAndEmailValidator.ValidateStudent(new Student());

            nameValidatorMock.Verify(x => x.ValidateStudent(It.IsAny<Student>()), Times.Once);
            emailValidatorMock.Verify(x => x.ValidateStudent(It.IsAny<Student>()), Times.Once);

            Assert.IsTrue(result);
        }

        [Test]
        public void IfNameIsIncorrectAndEmailIsIncorrectReturnFalse()
        {
            nameValidatorMock.Setup(x => x.ValidateStudent(It.IsAny<Student>())).Returns(false);
            emailValidatorMock.Setup(x => x.ValidateStudent(It.IsAny<Student>())).Returns(false);

            bool result = nameAndEmailValidator.ValidateStudent(new Student());

            nameValidatorMock.Verify(x => x.ValidateStudent(It.IsAny<Student>()), Times.Once);
            emailValidatorMock.Verify(x => x.ValidateStudent(It.IsAny<Student>()), Times.Never);

            Assert.IsFalse(result);
        }
    }
}
