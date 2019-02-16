using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

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
    }
}
