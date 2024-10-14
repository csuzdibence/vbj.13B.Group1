using Microsoft.AspNetCore.Mvc;
using StudentWebApp.Models;

namespace StudentWebApp.Controllers
{
    /// <summary>
    /// Controller a tanulókhoz kapcsolódó végpontokhoz
    /// </summary>
    public class StudentController : Controller
    {
        // FONTOS, ha nem static nem működik hiszen EGY listát használunk a futás során nem N-t (!!!)
        private static List<Student> students = new List<Student>();

        // Root végpont -> /Student
        public IActionResult Index()
        {
            return View(students);
        }

        // /Student/Register nézet
        public IActionResult Register()
        {
            return View();
        }

        // RegisterStudent action -> beszúrunk a listába egy új studentet amit a formról kaptunk
        public IActionResult RegisterStudent(Student student)
        {
            student.Id = students.Any() ? students.Last().Id + 1 : 1;
            student.DateOfRegistry = DateTime.Now;
            students.Add(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Student foundStudent = students.FirstOrDefault(x => x.Id == id);
            if (foundStudent != null)
            {
                students.Remove(foundStudent);
            }
            return RedirectToAction("Index");
        }
    }
}
