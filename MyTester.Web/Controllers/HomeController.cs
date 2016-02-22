using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTester.Models;

namespace MyTester.Controllers
{
    public class HomeController : Controller
    {
        private ITestRepo _testRepo;

        public HomeController(ITestRepo testRepo)
        {
            _testRepo = testRepo;//☻
        }

        // GET: Home
        public ActionResult Index()
        {
            //return View();

            return Redirect("~/app");
        }
    }
}