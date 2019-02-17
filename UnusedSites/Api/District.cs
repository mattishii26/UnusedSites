using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace UnusedSites.Api
{
    public class District
    {
        private string conString;

        public District()
        {
            conString = DbConnection.GetConnectionString();
        }

        public static DataTable GetAllDistricts()
        {
            string query = "SELECT dist.dist_name, un.contact_salutation, un.contact_fname, un.contact_lname, un.contact_phone," +
                "un.date_sent, un.date_received, un.form424_rec_date" +
                "FROM db.unused_dist as un, db.district as dist" +
                "WHERE dist.dist_code = un.dist_code;";
            return DbConnection.SelectQuery(query);
        }
    }
}
