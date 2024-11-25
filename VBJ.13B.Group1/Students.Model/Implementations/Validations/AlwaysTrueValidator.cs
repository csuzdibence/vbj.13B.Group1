using Students.Model.Interfaces;

namespace Students.Model
{
    public class AlwaysTrueValidator : IStudentValidator
    {
        public bool ValidateStudent(Student student)
        {
            return true;
        }
    }
}
