using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UnusedSites.Api
{
    public class DbConnection
    {
        private static IConfigurationRoot Configuration;

        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("websettings.json");

            Configuration = builder.Build();
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            return connectionString;
        }

        public static DataTable SelectQuery(string query)
        {
            DataTable temp;

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @query;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();

                        da.Fill(ds, "tablename");
                        con.Close();

                        temp = ds.Tables["tablename"];
                    }
                }
            }
            return temp;
        }
    }
}
