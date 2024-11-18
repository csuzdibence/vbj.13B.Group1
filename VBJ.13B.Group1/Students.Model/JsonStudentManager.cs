
using System.Text.Json;

namespace Students.Model
{
    public class JsonStudentManager : IStudentManager
    {
        private const string studentFileName = "students.json";

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
                return JsonSerializer.Deserialize<List<Student>>(jsonFile);
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
