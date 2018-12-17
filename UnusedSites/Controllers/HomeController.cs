using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnusedSites.Models;

namespace UnusedSites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult AccountHome()
        {
            ViewData["Title"] = "Account Home";
            return View();
        }

        public IActionResult AddSite()
        {
            ViewData["Title"] = "Add an Unused Site";
            return View();
        }

    }
}
