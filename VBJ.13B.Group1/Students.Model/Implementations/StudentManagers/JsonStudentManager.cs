using Students.Model.Implementations.Validations;
using Students.Model.Interfaces;
using System.Text.Json;

namespace Students.Model
{
    public class JsonStudentManager : IStudentManager
    {
        private const string studentFileName = "students.json";
        private IEverythingValidator studentValidator;

        public JsonStudentManager(IEverythingValidator studentValidator)
        {
            this.studentValidator = studentValidator;
        }

        public void Add(Student student)
        {
            var students = ReadStudents();
            students.Add(student);
            var jsonFile = JsonSerializer.Serialize(students);
            File.WriteAllText(studentFileName, jsonFile);
        }

        public List<Student> ReadStudents()
        {
            try
            {
                string jsonFile = File.ReadAllText(studentFileName);
                var students = JsonSerializer.Deserialize<List<Student>>(jsonFile);
                foreach (var student in students)
                {
                    student.IsValid = studentValidator.ValidateStudent(student);
                }
                return students;
            }
            catch (FileNotFoundException)
            {
                return new List<Student>();
            }
        }

        public void RemoveStudent(Student student)
        {
            var students = ReadStudents();
            students.Remove(student);
            var jsonFile = JsonSerializer.Serialize(students);
            File.WriteAllText(studentFileName, jsonFile);
        }
    }
}
