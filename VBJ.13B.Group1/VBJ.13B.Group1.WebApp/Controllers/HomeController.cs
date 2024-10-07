using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    // MVC Controller -> : Controller - >Controller osztály (ASP fejlesztõk írták) leszármazottja
    // õs osztály -> minden protected és public tagot elérünk
    public class HomeController : Controller
    {
        // Home View-k közötti, Index.cshtml-t adja vissza
        // Metódus megköti a View nevét
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
