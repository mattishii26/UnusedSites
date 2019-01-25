using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnusedSites.Models;

namespace UnusedSites.Data{
    public class SiteData{
        public static Site[] GetSites(){
            Site[] sites = new Site[4];
            sites[0] = new Site(1, "Alta Loma", "Campbell", "Used");
            sites[1] = new Site(2, "Bakers", "Harding", "Unused, Charged");
            sites[2] = new Site(3, "Hollister", "Smallwood", "Sold");
            sites[3] = new Site(4, "Loomis", "Taylor", "Modified");
            return sites;
        }
    }

}