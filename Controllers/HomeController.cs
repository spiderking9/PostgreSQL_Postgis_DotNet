using GeoTronic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GeoTronic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GeoContext db;

        public HomeController(ILogger<HomeController> logger)
        {
            db = new GeoContext();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(db.pointsLists);
        }

        public IActionResult Privacy()
        {
            ViewBag.Zbazy = db.howManyRows;
            return View(db.pointsLists);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
