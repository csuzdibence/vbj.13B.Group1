using Microsoft.AspNetCore.Mvc;
using Students.Model;
using Students.Model.Interfaces;

namespace StudentWebApp.Controllers
{

    public class TeacherController : Controller
    {
        private ITeacherManager teacherManager;
        private IEncryptService encryptService;
        private IAuthenticationService authenticationService;

        public TeacherController(ITeacherManager teacherManager, IEncryptService encryptService, IAuthenticationService authenticationService)
        {
            this.teacherManager = teacherManager;
            this.encryptService = encryptService;
            this.authenticationService = authenticationService;
        }

        // /Teacher - root oldal
        public IActionResult Index()
        {
            if (!authenticationService.IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            var teacher = teacherManager.GetAll().FirstOrDefault(x => x.EmailAddress == authenticationService.EmailAddress);


            return View(teacher.Students);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            authenticationService.LogOut();
            return RedirectToAction("Index");
        }

        // Login form beküldése során hívódik meg
        public IActionResult TryLogIn(string email, string password)
        {
            if (authenticationService.TryLogIn(email, password))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // Ha beküldjük a formot
        public IActionResult RegisterTeacher(Teacher teacher)
        {
            // Titkosítjuk a tanár jelszavát, majd eltároljuk
            teacher.Password = encryptService.HashPassword(teacher.Password);
            // Mentés valahova (de mi tudjuk, hogy ez adatbázis)
            teacherManager.Add(teacher);
            return RedirectToAction("Index");
        }
    }
}
