using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCore.Models;
using Microsoft.Extensions.Options;

namespace TestCore.Controllers
{
    public class HomeController : Controller
    {
        private IOptions<AppSettings> _settings;

        public HomeController(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }
        public IActionResult Index()
        {
            ViewBag.MyNodeName = _settings.Value.MyNodeName;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
