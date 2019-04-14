using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace UnusedSites.Api
{
    public class Site
    {

        enum Change { creation, updated }   // to be used with "Changes" column in db.approve

        public static Boolean CreateSite(int siteCode,int districtCode, int coCode, string siteName, int status, double numAcres, int monthLastUsed, int yearLastUsed,
            double purchasePrice, double appraisedValue, int monthAppraised, int yearAppraised, double currentValue, string gradeLevel, string changes, string reason)
        {
            string siteQuery = @"insert into db.site (dist_code, co_code, site_name, site_code, Status)
                            values(@p0, @p1, @p2, @p3, @p4)
                            ;";
            List<object> siteParam = new List<object>();
            siteParam.Add(districtCode);
            siteParam.Add(coCode);
            siteParam.Add(siteName);
            siteParam.Add(siteCode); 
            siteParam.Add(status);
            int siteRows = DbConnection.CUDQuery(siteQuery, siteParam);

            string unusedQuery = @"insert into db.unusedvb (dist_code, co_code, site_code, num_acres, mo_last_used, yr_last_used, purch_price, appraised_value,
                               mo_appraised, yr_appraised, current_value, grade_level, status, percent_assessed, rec_num, changes, reason)
                               values(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16)
                               ;";
            List<object> unusedParam = new List<object>();
            unusedParam.Add(districtCode);
            unusedParam.Add(coCode);
            unusedParam.Add(siteCode); 
            unusedParam.Add((decimal) numAcres);
            unusedParam.Add(monthLastUsed);
            unusedParam.Add(yearLastUsed);
            unusedParam.Add((decimal) purchasePrice);
            unusedParam.Add((decimal) appraisedValue);
            unusedParam.Add(monthAppraised);
            unusedParam.Add(yearAppraised);
            unusedParam.Add((decimal) currentValue);
            unusedParam.Add(gradeLevel);
            unusedParam.Add(status);
            unusedParam.Add((short) 90); // ask percent assessed
            unusedParam.Add(7000); // ask rec_num
            unusedParam.Add(changes);
            unusedParam.Add(reason);
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

                public static DataTable GetSite(int site_code)
        {
            //check to make sure this matches API fields, missing changes, reason, approved
            string query = @"SELECT site.site_code, dist.dist_name, site.site_name, site.Status, un.num_acres, 
                                    un.mo_last_used, un.yr_last_used, un.purch_price, un.appraised_value, 
                                    un.mo_appraised, un.yr_appraised, un.current_value, un.grade_level
                            FROM db.site as site,  db.unusedvb as un, db.district as dist
                            WHERE site.site_code = @p0 
                            AND site.dist_code = un.dist_code AND site.dist_code = dist.dist_code;";
            List<object> siteGetParams = new List<object>();
            siteGetParams.Add(site_code);

            return DbConnection.SelectQuery(query, siteGetParams); ;
        }

        /*public static Boolean UpdateSite(int id, String district, String name, String status, double numAcres
                                         int monthLastUsed, int yearLastUsed, double purchasePrice, double appraisedValue,
                                         int monthAppraised, int yearAppraised, double currentValue, String gradeLevel
                                         )
      

            return false;

        }*/

        // External UpdateSite
        // Updates a site entry in Approve Table for review
        public static Boolean ExtUpdateSite(Dictionary<string, object> columns) {

            List<object> prms = new List<object>();
            string request;
            string update = @"UPDATE db.approve ";
            string set = @"SET Changes = @p0, ";
            string where = @"WHERE dist_code = @p1 AND site_code = @p2;";

            prms.Add(Change.updated.ToString());    // @p0

            object dist_code, site_code;
            if (!(columns.TryGetValue("dist_code", out dist_code) && columns.TryGetValue("site_code", out site_code))) {
                // basically, this means you didn't successfully add either dist/site code to the dictionary
                return false;
            }
            // if all goes well.
            prms.Add((int) dist_code);    // @p1
            prms.Add((int) site_code);    // @p2

            int count = 3;
            foreach (KeyValuePair<string,object> kv in columns) {
                set += kv.Key + @" = @p" + count + ", ";
                prms.Add(kv.Value);
                count++;
            }

            request = update + set.TrimEnd(',') + where;
            
            if (DbConnection.CUDQuery(request, prms) > 0)
                return true;
            return false;

        }

        // External CreateSite Function:
        // Push new site to Approve Table for review
        public static Boolean ExtCreateSite(Dictionary<string, object> columns) {

            List<object> prms = new List<object>();
            string request;
            string insert = @"INSERT INTO db.approve (";
            string values = @"VALUES (";

            columns.Add("Changes", Change.creation.ToString()); // use Change enum, for consistency.

            int count = 0;
            foreach (KeyValuePair<string,object> kv in columns) {
                insert += kv.Key + ", ";
                values += @"@p" + count + ", ";
                prms.Add(kv.Value);
                count++;
            }

            insert = insert.TrimEnd(new char[] { ',', ' ' }) + ") ";
            values = values.TrimEnd(new char[] { ',', ' ' }) + ");";
            request = insert + values;

            if (DbConnection.CUDQuery(request, prms) > 0)
                return true;
            return false;
        }

    }
}
