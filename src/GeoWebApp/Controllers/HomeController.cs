using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeoWebApp.Models;
using Microsoft.Extensions.Options;

namespace GeoWebApp.Controllers
{
    public class HomeController : Controller
    {
        protected readonly AppSettings _appSettings;

        public HomeController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            ViewBag.DataCenter = Environment.GetEnvironmentVariable("DATA_CENTER") ?? "Unknown";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
