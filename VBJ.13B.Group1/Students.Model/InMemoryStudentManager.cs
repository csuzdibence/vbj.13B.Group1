using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model
{
    public class InMemoryStudentManager : IStudentManager
    {
        private static List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public List<Student> ReadStudents()
        {
            return students;
        }
    }
}
