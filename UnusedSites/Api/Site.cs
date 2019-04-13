﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnusedSites.Api
{
    public class Site
    {

        public static Boolean CreateSite(string districtCode, string coCode, string siteName, string status, double numAcres, int monthLastUsed, int yearLastUsed,
            double purchasePrice, double appraisedValue, int monthAppraised, int yearAppraised, double currentValue, string gradeLevel)
        {
            string siteQuery = @"insert into db.site (dist_code, co_code, site_name, site_code, Status)
                            values(@p0, @p1, @p2, @p3, @p4, @p5)
                            ;";
            List<object> siteParam = new List<object>();
            siteParam.Add(districtCode);
            siteParam.Add(coCode);
            siteParam.Add(siteName);
            siteParam.Add(12345); // this is currently hard coded, will need to be updated when i ask how it is populated
            siteParam.Add(status);
            int siteRows = DbConnection.CUDQuery(siteQuery, siteParam);

            string unusedQuery = @"insert into db.unusedvb (dist_code, co_code, site_code, num_acres, mo_last_used, yr_last_used, purch_price, appraised_value,
                               mo_appraised, yr_appraised, current_value, grade_level)
                               values(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)
                               ;";
            List<object> unusedParam = new List<object>();
            unusedParam.Add(districtCode);
            unusedParam.Add(coCode);
            unusedParam.Add(12345); // this is currently hard coded, will need to be updated when i ask how it is populated
            unusedParam.Add(numAcres);
            unusedParam.Add(monthLastUsed);
            unusedParam.Add(yearLastUsed);
            unusedParam.Add(purchasePrice);
            unusedParam.Add(appraisedValue);
            unusedParam.Add(monthAppraised);
            unusedParam.Add(yearAppraised);
            unusedParam.Add(currentValue);
            unusedParam.Add(gradeLevel);
            int unusedRows = DbConnection.CUDQuery(unusedQuery, unusedParam);

            if (unusedRows > 0 && siteRows > 0)
            {
                return true;
            }

            return false;
        }

        public static Boolean DeleteSite(int dist_code, int site_code)
        {
            string delete = @"DELETE FROM db.site
                              WHERE dist_code = @p0 AND site_code = @p1;";
            List<object> dprms = new List<object>();
            dprms.Add(dist_code);
            dprms.Add(site_code);

            DateTime time = DateTime.Now;
            string update = @"UPDATE db.unusedvb
                              SET site_deleted = @p0
                              WHERE dist_code = @p1 AND site_code = @p2;";
            List<object> sprms = new List<object>();
            sprms.Add(time);
            sprms.Add(dist_code);
            sprms.Add(site_code);

            if (DbConnection.CUDQuery(delete, dprms) > 0 && DbConnection.CUDQuery(update, sprms) > 0)
                return true;
            return false;
        }

    }
}