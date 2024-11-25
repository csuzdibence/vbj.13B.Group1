using Microsoft.AspNetCore.Mvc;
using Students.Model;
using Students.Model.Implementations.Validations;
using Students.Model.Interfaces;

namespace StudentWebApp.Controllers
{
    /// <summary>
    /// Controller a tanulókhoz kapcsolódó végpontokhoz
    /// </summary>
    public class StudentController : Controller
    {        
        IStudentManager studentManager;
        IEverythingValidator studentValidator;

        // Dependency Injection / Konstruktor Injection
        public StudentController(IStudentManager studentManager, IEverythingValidator studentValidator)
        {
            this.studentValidator = studentValidator;
            this.studentManager = studentManager;
        }

        // Root végpont -> /Student
        public IActionResult Index()
        {
            return View(studentManager.ReadStudents());
        }

        // /Student/Register nézet
        public IActionResult Register()
        {
            return View();
        }

        // RegisterStudent action -> beszúrunk a listába egy új studentet amit a formról kaptunk
        public IActionResult RegisterStudent(Student student)
        {
            var students = studentManager.ReadStudents();
            student.Id = students.Any() ? students.Last().Id + 1 : 1;
            student.DateOfRegistry = DateTime.Now;
            student.IsValid = studentValidator.ValidateStudent(student);
            studentManager.Add(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var students = studentManager.ReadStudents();
            Student foundStudent = students.FirstOrDefault(x => x.Id == id);
            if (foundStudent != null)
            {
                studentManager.RemoveStudent(foundStudent);
            }
            return RedirectToAction("Index");
        }
    }
}
