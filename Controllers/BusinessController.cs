using System.Web.Mvc;
using MyMvcProject.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Web.Hosting;

namespace MyMvcProject.Controllers
{
    public class BusinessController : Controller
    {
        private static List<Place> _places;

        public BusinessController()
        {
            // Initialize the places list by loading it from the JSON file
            if (_places == null)
            {
                LoadPlacesFromJson();
            }
        }

        private void LoadPlacesFromJson()
        {
            // Path to the JSON file
            string path = HostingEnvironment.MapPath("~/App_Data/data.json");
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                _places = JsonConvert.DeserializeObject<List<Place>>(json);
            }
        }

        // GET: Business
        public ActionResult Index()
        {
            return View(_places); // Passes the list of places to the View located at ~/Views/Business/Index.cshtml
        }

        // GET: Business/Details/5
        public ActionResult Details(int id)
        {
            var place = _places.Find(p => p.BusinessId == id);
            if (place == null)
            {
                return HttpNotFound();  // Returns a standard 404 Not Found response if no place is found
            }
            return View(place);  // Passes the found place to the View located at ~/Views/Business/Details.cshtml
        }
    }
}