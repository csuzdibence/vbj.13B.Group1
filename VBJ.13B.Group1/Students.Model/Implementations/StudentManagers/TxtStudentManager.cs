
namespace Students.Model
{
    public class TxtStudentManager : IStudentManager
    {
        private const string txtFileName = "students.txt";
        private const char delimiter = ';';

        public void Add(Student student)
        {
            string[] lines = new string[1];
            lines[0] = student.ToString();
            File.AppendAllLines(txtFileName, lines);
        }

        public List<Student> ReadStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                foreach (var lines in File.ReadAllLines(txtFileName))
                {
                    var data = lines.Split(delimiter);
                    students.Add(new Student()
                    {
                        Id = int.Parse(data[0]),
                        FirstName = data[1],
                        LastName = data[2],
                        EmailAddress = data[3],
                        DateOfRegistry = DateTime.Parse(data[4]),
                        IsValid = bool.Parse(data[5])
                    });
                };
            }
            catch (Exception)
            {
                return new List<Student>();
            }
            return students;
        }

        public void RemoveStudent(Student student)
        {
            File.WriteAllLines(txtFileName, 
                File.ReadAllLines(txtFileName)
                .Where(x => 
                    int.Parse(x.Split(delimiter).First()) != student.Id));
        }
    }
}
