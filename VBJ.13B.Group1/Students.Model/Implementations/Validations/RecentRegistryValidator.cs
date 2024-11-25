using Students.Model.Interfaces;

namespace Students.Model.Implementations.Validations
{
    public class RecentRegistryValidator : IStudentValidator
    {
        public bool ValidateStudent(Student student)
        {
            return student.DateOfRegistry > DateTime.Now.Subtract(TimeSpan.FromDays(365));
        }
    }
}
