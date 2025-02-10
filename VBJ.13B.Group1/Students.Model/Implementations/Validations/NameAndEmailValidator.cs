using Students.Model.Interfaces;

namespace Students.Model
{
    public class NameAndEmailValidator : IStudentValidator
    {
        INameLengthValidator nameValidator;
        IEmailDomainValidator emailValidator;

        public NameAndEmailValidator(INameLengthValidator nameValidator, IEmailDomainValidator emailValidator)
        {
            this.nameValidator = nameValidator;
            this.emailValidator = emailValidator;
        }

        public bool ValidateStudent(Student student)
        {
            return nameValidator.ValidateStudent(student) && emailValidator.ValidateStudent(student);
        }
    }
}
