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

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("websettings.json");

            Configuration = builder.Build();
            var dataSource = "Data Source=" + Configuration["ConnectionStrings:DataSource"] + "; ";
            var catalog = "Initial Catalog=" + Configuration["ConnectionStrings:InitialCatalog"] + "; ";
            var user = "User id=" + Configuration["ConnectionStrings:UserId"] + "; ";
            var password = "Password=" + Configuration["ConnectionStrings:Password"] + "; ";
            return dataSource + catalog + user + password;
        }

        /**
         *  Basic Select Query
         *  
         *  return DataTable
         **/
        public static DataTable SelectQuery(string query, List<object> paramVals)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        int count = 0;
                        foreach (object o in paramVals)
                        {
                            if (o is string) { cmd.Parameters.Add("@p" + count, SqlDbType.NVarChar); }
                            else if (o is int) { cmd.Parameters.Add("@p" + count, SqlDbType.Int); }
                            else if (o is short) { cmd.Parameters.Add("@p" + count, SqlDbType.SmallInt); }
                            else if (o is DateTime) { cmd.Parameters.Add("@p" + count, SqlDbType.SmallDateTime); }
                            cmd.Parameters["@p" + count].Value = o;
                            count++;
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();

                            da.Fill(ds, "table");
                            con.Close();

                            data = ds.Tables["table"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //logging
            }
            return data;
        }

        /**
         * Basic Query for Create Update and Delete
         * 
         * return int - number of rows affected, 0 means failed
         **/
        public static int CUDQuery(string query, List<object> paramVals)
        {
            int res = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        int count = 0;
                        foreach (object o in paramVals)
                        {
                            if (o is string) { cmd.Parameters.Add("@p" + count, SqlDbType.NVarChar); }
                            else if (o is int) { cmd.Parameters.Add("@p" + count, SqlDbType.Int); }
                            else if (o is short) { cmd.Parameters.Add("@p" + count, SqlDbType.SmallInt); }
                            else if (o is DateTime) { cmd.Parameters.Add("@p" + count, SqlDbType.SmallDateTime); }
                            cmd.Parameters["@p" + count].Value = o;
                            count++;
                        }
                        res = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // logging
            }
            return res;
        }

    }
}
