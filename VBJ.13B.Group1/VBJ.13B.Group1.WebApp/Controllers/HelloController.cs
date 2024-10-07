using Microsoft.AspNetCore.Mvc;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    // /Hello url
    public class HelloController : Controller
    {
        // /Hello
        public IActionResult Index()
        {
            return View();
        }

        // /Hello/Hello
        public IActionResult Hello()
        {
            return View();
        }

        public IActionResult Asd()
        {
            return View("Hello");
        }
    }
}
