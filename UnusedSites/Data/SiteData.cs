using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnusedSites.Models;

namespace UnusedSites.Data{
    public class SiteData{
        public static Site[] GetSites(){ //all sites for a district
            Site[] sites = new Site[4];
            sites[0] = new Site(1, "Alta Loma", "Campbell", "Used",1.3,11,2018,34000,27000, 08, 2012,35000,"k-12","Submitted", "NA", "No");
            sites[1] = new Site(2, "Bakers", "Harding", "Unused",4, 07, 2018, 62000, 55000, 11, 2013, 52000, "k-12","Submitted", "3", "Yes"); 
            sites[2] = new Site(3, "Hollister", "Smallwood", "Sold",5, 01, 2018, 52000, 65000, 01, 2015, 62000, "k-12","Submitted", "NA", "Yes");
            sites[3] = new Site(4, "Loomis", "Taylor", "Unused",6, 12, 2018, 19000, 24000, 12, 2017, 22000, "k-12","Submitted", "2", "Yes");
            return sites;
        }

        public static District GetDistrict(int id) // single district for distirct page
        {
            Site[] sites = new Site[4];
            sites[0] = new Site(1, "Alta Loma", "Campbell", "Used", 1.3, 11, 2018, 34000, 27000, 03, 2012, 35000, "k-8","Submitted", "NA", "No");
            sites[1] = new Site(2, "Bakers", "Harding", "Unused", 4, 07, 2018, 62000, 12, 55000, 2013, 52000, "k-12","Submitted", "N3", "Yes");
            sites[2] = new Site(3, "Hollister", "Smallwood", "Sold", 5, 01, 2018, 52000, 65000, 11, 2015, 62000, "k-12","Submitted", "NA", "Yes");
            sites[3] = new Site(4, "Loomis", "Taylor", "Unused", 6, 12, 2018, 19000, 24000, 07, 2017, 22000, "6-8","Submitted", "2", "Yes");

            District dist = new District(1, "Alta Loma", "Mr.", "John", "Doe", "(916)461-4621","06/24/2017","07/07/2017", "07/07/2017", sites.ToList());

            return dist;
        }

        public static District[] GetDistricts() // all districts for dashboard 
        {
            District[] districts = new District[4];
            districts[0] = new District(1, "Alpine", "Mr.", "Fergus", "Reid", "(916)461-4621","06/24/2017","07/07/2017", "07/07/2017",4);
            districts[1] = new District(2, "Alta Loma", "Mrs.", "Helen", "Winter", "(530)427-4234","06/02/2017","07/01/2017", "07/01/2017",3);
            districts[2] = new District(3, "Clovis", "Mr.", "William", "Blazkowicz", "(486)364-2356","05/24/2017","06/07/2017", "06/12/2017",6);
            districts[3] = new District(4, "Folsom", "Mrs.", "Anya", "Oliwa", "(712)315-2358","03/20/2017","04/07/2017", "04/23/2017",2);

            return districts;

        }

        public static Site[] GetSite(int Id) // Every year of the same Site
        {
            Site[] sites = new Site[4];
            sites[0] = new Site(1, "Alta Loma", "Campbell", "Used", 1.3, 11, 2018, 34000, 27000, 08, 2017, 35000, "k-12", "Submitted", "NA", "No");
            sites[1] = new Site(2, "Alta Loma", "Campbell", "Used", 1.3, 11, 2017, 35145, 31897, 09, 2016, 36631, "k-12", "Submitted", "NA", "No"); 
            sites[2] = new Site(3, "Alta Loma", "Campbell", "Used", 1.3, 11, 2016, 37142, 25453, 10, 2015, 37656, "k-12", "Submitted", "NA", "No");
            sites[3] = new Site(4, "Alta Loma", "Campbell", "Used", 1.3, 11, 2015, 32189, 29235, 07, 2014, 31646, "k-12", "Submitted", "NA", "No");
            return sites;
        }

    }

}