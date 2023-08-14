using Deck_of_Cards_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace Deck_of_Cards_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        public IActionResult Index()
        {
            DrawFiveModel result = DrawFiveDAL.GetDrawFive();
            if (result.remaining <= 0)
            {
                ReshuffleDAL.GetReshuffle();
            }
            
            return View(result);
        }
        public IActionResult Result()
        {
            return View();
        }
        //public IActionResult Reshuffle()
        //{
            
        //    return RedirectToAction("Result");
        //}
        //public IActionResult Results()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}