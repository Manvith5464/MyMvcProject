using Microsoft.AspNetCore.Mvc;
using MyMvcProject.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace MyMvcProject.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private List<Place> _places;

        public BusinessController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            LoadPlacesFromJson();
        }

        private void LoadPlacesFromJson()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string jsonFilePath = Path.Combine(contentRootPath, "App_Data", "data.json");
            string json = System.IO.File.ReadAllText(jsonFilePath);
            _places = JsonSerializer.Deserialize<List<Place>>(json);
        }

        public IActionResult Index()
        {
            return View(_places); // Serves the ~/Views/Business/Index.cshtml view with places list
        }

        public IActionResult Details(int id)
        {
            var place = _places.FirstOrDefault(p => p.BusinessId == id);
            if (place == null)
            {
                return NotFound();  // Returns a 404 Not Found response if no place is found
            }
            return View(place);  // Serves the ~/Views/Business/Details.cshtml view with a single place
        }
    }
}

