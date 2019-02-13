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
            sites[0] = new Site(1, "Alta Loma", "Campbell", "Used",1.3,11,2018,34000,27000, 08, 2012,35000,"k-12","Submitted", "NA", "No");
            sites[1] = new Site(2, "Bakers", "Harding", "Unused",4, 07, 2018, 62000, 55000, 11, 2013, 52000, "k-12","Submitted", "3", "Yes"); 
            sites[2] = new Site(3, "Hollister", "Smallwood", "Sold",5, 01, 2018, 52000, 65000, 01, 2015, 62000, "k-12","Submitted", "NA", "Yes");
            sites[3] = new Site(4, "Loomis", "Taylor", "Unused",6, 12, 2018, 19000, 24000, 12, 2017, 22000, "k-12","Submitted", "2", "Yes");
            return sites;
        }

        public static District GetDistrictInfo(String district)
        {
            Site[] sites = new Site[4];
            sites[0] = new Site(1, "Alta Loma", "Campbell", "Used", 1.3, 11, 2018, 34000, 27000, 03, 2012, 35000, "k-8","Submitted", "NA", "No");
            sites[1] = new Site(2, "Bakers", "Harding", "Unused", 4, 07, 2018, 62000, 12, 55000, 2013, 52000, "k-12","Submitted", "N3", "Yes");
            sites[2] = new Site(3, "Hollister", "Smallwood", "Sold", 5, 01, 2018, 52000, 65000, 11, 2015, 62000, "k-12","Submitted", "NA", "Yes");
            sites[3] = new Site(4, "Loomis", "Taylor", "Unused", 6, 12, 2018, 19000, 24000, 07, 2017, 22000, "6-8","Submitted", "2", "Yes");

            District dist = new District(1, "Alta Loma", "Mr.", "John", "Doe", "(916)461-4621","06/24/2017","07/07/2017", "07/07/2017", sites.ToList());

            return dist;
        }

        public static Site GetSite(String district)
        {
            //Site[] sites = new Site[4];
            Site site = new Site(1, "Alta Loma", "Campbell", "Used", 1.3, 11, 2018, 34000, 27000, 11, 2012, 35000, "k-12","Submitted", "NA", "yes");
            //sites[1] = new Site(2, "Bakers", "Harding", "Unused, Charged");
            //sites[2] = new Site(3, "Hollister", "Smallwood", "Sold");
            //sites[3] = new Site(4, "Loomis", "Taylor", "Modified");

            //District dist = new District(1, "Alta Loma", "Campbell", "Used", sites.ToList());

            return site;
        }

    }

}