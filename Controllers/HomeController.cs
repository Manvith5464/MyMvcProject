

using Microsoft.AspNetCore.Mvc;
 
namespace MyMvcProject.Controllers

{

    public class HomeController : Controller

    {

        // GET: /

        public IActionResult Index()

        {

            return View(); // Corresponds to the view in Views/Home/Index.cshtml

        }

        // GET: /Home/About

        public IActionResult About()

        {

            return View(); // Corresponds to the view in Views/Home/About.cshtml

        }

    }

}
