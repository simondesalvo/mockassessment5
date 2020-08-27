using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockAssessment5b.Models;

namespace MockAssessment5b.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAge()
        {
            ViewBag.NameAndAge = "Put in your name and age";

            return View();
        }

        public IActionResult Result(string UserName, int Age)
        {
            if (Age < 18)
            {
                ViewData["TooYoung"] = $"{UserName} is still in high school.";
                return View();
            }
            else if (Age == 18)
            {
                ViewData["CanVote"] = $"{UserName} can Vote";
                return View();
            }
            else if (Age >= 21 && Age <25) //old enough to vote and drink but not old enough to rent a car cheaply
            {
                ViewData["CanVote"] = $"{UserName} can Vote";
                ViewData["CanDrink"] = $"{UserName} can Drink";
                return View();
            }
            else if (Age >= 25) //old enough for all the things
            {
                ViewData["CanVote"] = $"{UserName} can Vote";
                ViewData["CanDrink"] = $"{UserName} can Drink";
                ViewData["CanRent"] = $"{UserName} can Drive"; //literally what the assignment said, I know you can drive at 16
                return View();
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
