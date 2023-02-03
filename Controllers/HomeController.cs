using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentRegistrationSys.Models;
using StudentRegistrationSys.Models.Data;

namespace StudentRegistrationSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentInfoContext _context;

        private readonly ILogger<HomeController> _logger;
        const string SessionName = "_Name";
        const string SessionAccount = "_Account";
        const string SessionId = "_Id";

        public HomeController(ILogger<HomeController> logger,StudentInfoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.acc = HttpContext.Session.GetInt32(SessionAccount);
            ViewBag.accid = HttpContext.Session.GetInt32(SessionId);

            return View();
        }

        public IActionResult StudentIndex()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.acc = HttpContext.Session.GetInt32(SessionAccount);
            ViewBag.accid = HttpContext.Session.GetInt32(SessionId);

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
