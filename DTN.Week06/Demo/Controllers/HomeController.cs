using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (login.userName == "Peter" && login.password == "pass@123")
            {
                string msg = "Welcome " + login.userName;
                return Content(msg);
            }
            else
            {
                return View();
            }
        }

        //public ActionResult Index()
        //{
        //    var user = new List<User>();
        //    //Code to populate the user collection
        //    return View(user);
        //}

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
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
