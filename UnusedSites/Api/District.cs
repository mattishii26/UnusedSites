using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace UnusedSites.Api
{
    public class District
    {
        public static DataTable GetAllDistricts()
        {
            string query = @"SELECT dist.dist_code, dist.dist_name, un.contact_salutation, un.contact_fname, un.contact_lname, un.contact_phone,
                un.date_sent, un.date_received, un.form424_rec_date
                FROM db.unused_dist as un, db.district as dist
                WHERE dist.dist_code = un.dist_code;";
            return DbConnection.SelectQuery(query, new List<object>());
        }

        public static DataTable GetDistrict(int dist_code)
        {
            string query = @"SELECT dist.dist_code, dist.dist_name, un.contact_salutation, un.contact_fname, un.contact_lname, un.contact_phone,
                un.date_sent, un.date_received, un.form424_rec_date
                FROM db.unused_dist as un, db.district as dist
                WHERE dist.dist_code = un.dist_code
                AND dist.dist_code = @p0;";
            List<object> param = new List<object>();
            param.Add(dist_code);

            return DbConnection.SelectQuery(query, param);
        }

    }

}
