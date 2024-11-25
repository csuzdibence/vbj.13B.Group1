using Students.Model.Interfaces;

namespace Students.Model
{
    public class NameAndEmailValidator : IStudentValidator
    {
        NameLengthValidator nameValidator;
        EmailDomainValidator emailValidator;

        public NameAndEmailValidator(NameLengthValidator nameValidator, EmailDomainValidator emailValidator)
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
