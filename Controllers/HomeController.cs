using System.Web.Mvc;

namespace MyMvcProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(); // Returns the View located at ~/Views/Home/Index.cshtml
        }

        // GET: Home/About
        public ActionResult About()
        {
            return View(); // Returns the View located at ~/Views/Home/About.cshtml
        }
    }
}