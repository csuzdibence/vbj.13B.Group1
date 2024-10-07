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
    }
}
