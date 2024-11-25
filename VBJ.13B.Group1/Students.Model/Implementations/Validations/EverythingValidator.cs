using Students.Model.Interfaces;

namespace Students.Model.Implementations.Validations
{
    public class EverythingValidator : IEverythingValidator
    {
        IEnumerable<IStudentValidator> studentValidators;

        public EverythingValidator(IEnumerable<IStudentValidator> studentValidators)
        {
            this.studentValidators = studentValidators;
        }

        public bool ValidateStudent(Student student)
        {
            foreach (var validator in studentValidators)
            {
                bool isValid = validator.ValidateStudent(student);
                if (!isValid)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
