using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnusedSites.Models;
using UnusedSites.Data;

namespace UnusedSites.Controllers
{
    public class UnusedSitesController : Controller
    {
        public IActionResult Home()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult AddSite()
        {
            ViewData["Title"] = "Add an Unused Site";
            return View();
        }

        public IActionResult Dashboard()
        {
            var sites =  SiteData.GetSites().ToList();
            ViewData["Title"] = "Dashboard";
            return View(sites);
        }

        public IActionResult District(int id)
        {
            var dist = SiteData.GetDistrict(id);
            ViewData["Title"] = "District";
            
            return View(dist);
        }

        public IActionResult Site(int id, int districtId)
        {
            var site = SiteData.GetSite(id)[0];
            ViewData["Title"] = "DistrictSites";
            ViewData["districtId"] = districtId;

            return View(site);
        }
    }
}
