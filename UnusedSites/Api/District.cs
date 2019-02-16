using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnusedSites.Api
{
    public class District
    {
        private string conString;

        public District()
        {
            conString = DbConnection.GetConnectionString();
        }


    }
}
