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
        public IActionResult Index(IOptions<AppSettings> settings)
        {
            ViewBag.MyNodeNAme = settings.Value.MyNodeName;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
