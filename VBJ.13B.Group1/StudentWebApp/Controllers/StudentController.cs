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
        private IAuthenticationService authService;
        private ITeacherManager teacherManager;

        // Dependency Injection / Konstruktor Injection
        public StudentController(IStudentManager studentManager, IEverythingValidator studentValidator, IAuthenticationService authService, ITeacherManager teacherManager)
        {
            this.studentValidator = studentValidator;
            this.studentManager = studentManager;
            this.authService = authService;
            this.teacherManager = teacherManager;
        }

        // Root végpont -> /Student
        public IActionResult Index()
        {
            if (!authService.IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(studentManager.ReadStudents());
        }

        // /Student/Register nézet
        public IActionResult Register()
        {
            if (!authService.IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // RegisterStudent action -> beszúrunk a listába egy új studentet amit a formról kaptunk
        public IActionResult RegisterStudent(Student student)
        {
            var teacher = teacherManager.GetAll().FirstOrDefault(x => authService.EmailAddress == x.EmailAddress);
            var students = studentManager.ReadStudents();
            student.Id = students.Any() ? students.Last().Id + 1 : 1;
            student.Password = student.Id.ToString();
            student.DateOfRegistry = DateTime.Now;
            student.IsValid = studentValidator.ValidateStudent(student);
            student.TeacherId = teacher.Id;
            studentManager.Add(student);
            return RedirectToAction("Index", "Teacher");
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
