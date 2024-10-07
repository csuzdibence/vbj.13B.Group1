using Microsoft.AspNetCore.Mvc;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Add Action
        [HttpPost]
        public IActionResult Add(int number1, int number2)
        {
            // logic
            int sum = number1 + number2;
            // store logic result
            ViewBag.Result = sum;

            // present result
            return View("Index");
        }
    }
}
