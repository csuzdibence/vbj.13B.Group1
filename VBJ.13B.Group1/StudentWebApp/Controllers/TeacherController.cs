using Microsoft.AspNetCore.Mvc;
using Students.Model;
using Students.Model.Interfaces;

namespace StudentWebApp.Controllers
{

    public class TeacherController : Controller
    {
        private ITeacherManager teacherManager;

        public TeacherController(ITeacherManager teacherManager)
        {
            this.teacherManager = teacherManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        // Ha beküldjük a formot
        public IActionResult RegisterTeacher(Teacher teacher)
        {
            teacherManager.Add(teacher);
            return RedirectToAction("Index");
        }
    }
}
