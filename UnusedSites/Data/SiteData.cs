using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnusedSites.Models;

namespace UnusedSites.Data{
    public class SiteData{
        public static District GetDistrict(int id) // single district for distirct page
        {
            var sitetableinfo = Api.Site.GetSites(id);
            Site[] sites = new Site[sitetableinfo.Rows.Count];
            for (int j = 0; j < sitetableinfo.Rows.Count; j++)
            {
                sites[j] = new Site(
                    int.Parse(sitetableinfo.Rows[j].ItemArray[0].ToString()),
                    sitetableinfo.Rows[j].ItemArray[1].ToString(), 
                    sitetableinfo.Rows[j].ItemArray[2].ToString(), 
                    sitetableinfo.Rows[j].ItemArray[3].ToString(), 
                    double.Parse(sitetableinfo.Rows[j].ItemArray[4].ToString()), 
                    int.Parse(sitetableinfo.Rows[j].ItemArray[5].ToString()), 
                    int.Parse(sitetableinfo.Rows[j].ItemArray[6].ToString()), 
                    double.Parse(sitetableinfo.Rows[j].ItemArray[7].ToString()), 
                    double.Parse(sitetableinfo.Rows[j].ItemArray[8].ToString()), 
                    int.Parse(sitetableinfo.Rows[j].ItemArray[9].ToString()),
                    int.Parse(sitetableinfo.Rows[j].ItemArray[10].ToString()), 
                    double.Parse(sitetableinfo.Rows[j].ItemArray[11].ToString()), 
                    sitetableinfo.Rows[j].ItemArray[12].ToString(), 
                    sitetableinfo.Rows[j].ItemArray[13].ToString(), 
                    sitetableinfo.Rows[j].ItemArray[14].ToString(), 
                    "No" 
                );
            }
            var datatableinfo = Api.District.GetDistrict(id);
            var district = new District(
                int.Parse(datatableinfo.Rows[0].ItemArray[0].ToString()), 
                datatableinfo.Rows[0].ItemArray[1].ToString(),
                datatableinfo.Rows[0].ItemArray[2].ToString(), 
                datatableinfo.Rows[0].ItemArray[3].ToString(), 
                datatableinfo.Rows[0].ItemArray[4].ToString(), 
                datatableinfo.Rows[0].ItemArray[5].ToString(), 
                datatableinfo.Rows[0].ItemArray[6].ToString(), 
                datatableinfo.Rows[0].ItemArray[7].ToString(), 
                datatableinfo.Rows[0].ItemArray[8].ToString(),
                sites.ToList());

            return district;
        }

        public static District[] GetDistricts() // all districts for dashboard 
        {
            var datatableinfo = Api.District.GetAllDistricts();
            District[] districts = new District[datatableinfo.Rows.Count];
            for (int j = 0; j < datatableinfo.Rows.Count; j++)
            {
                districts[j] = new District(
                    int.Parse(datatableinfo.Rows[j].ItemArray[0].ToString()), 
                    datatableinfo.Rows[j].ItemArray[1].ToString(),
                    datatableinfo.Rows[j].ItemArray[2].ToString(), 
                    datatableinfo.Rows[j].ItemArray[3].ToString(), 
                    datatableinfo.Rows[j].ItemArray[4].ToString(), 
                    datatableinfo.Rows[j].ItemArray[5].ToString(), 
                    datatableinfo.Rows[j].ItemArray[6].ToString(), 
                    datatableinfo.Rows[j].ItemArray[7].ToString(), 
                    datatableinfo.Rows[j].ItemArray[8].ToString(),
                    4);
            }
            return districts;

        }

        public static Site[] GetSite(int Id) // Every year of the same Site
        {
            var sitetableinfo = Api.Site.GetSite(Id);
            Site[] sites = new Site[sitetableinfo.Rows.Count];
            for (int j = 0; j < sitetableinfo.Rows.Count; j++)
            {
                sites[j] = new Site(
                    int.Parse(sitetableinfo.Rows[j].ItemArray[0].ToString()),
                    sitetableinfo.Rows[j].ItemArray[1].ToString(), 
                    sitetableinfo.Rows[j].ItemArray[2].ToString(), 
                    sitetableinfo.Rows[j].ItemArray[3].ToString(), 
                    double.Parse(sitetableinfo.Rows[j].ItemArray[4].ToString()), 
                    int.Parse(sitetableinfo.Rows[j].ItemArray[5].ToString()), 
                    int.Parse(sitetableinfo.Rows[j].ItemArray[6].ToString())-j, //used to track the year records, bad way of handling this, fix asap
                    double.Parse(sitetableinfo.Rows[j].ItemArray[7].ToString()), 
                    double.Parse(sitetableinfo.Rows[j].ItemArray[8].ToString()), 
                    int.Parse(sitetableinfo.Rows[j].ItemArray[9].ToString()),
                    int.Parse(sitetableinfo.Rows[j].ItemArray[10].ToString()), 
                    double.Parse(sitetableinfo.Rows[j].ItemArray[11].ToString()), 
                    sitetableinfo.Rows[j].ItemArray[12].ToString(), 
                    sitetableinfo.Rows[j].ItemArray[13].ToString(), 
                    sitetableinfo.Rows[j].ItemArray[14].ToString(), 
                    "No" 
                );
            }
            return sites;
        }

    }

}