using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace StudentWebApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
