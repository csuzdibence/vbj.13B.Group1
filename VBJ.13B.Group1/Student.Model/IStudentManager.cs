namespace Student.Model
{
    public interface IStudentManager
    {
        List<Student> ReadStudents();
        void AddStudent(Student student);
        void RemoveStudent(Student student);
    }
}
