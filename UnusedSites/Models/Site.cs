using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//Model for the site objects
namespace UnusedSites.Models{
    public class Site{
        public Site(int Id, string District, string Name, string Status){
            this.Id = Id;
            this.District = District;
            this.Name = Name;
            this.Status = Status;
        } 
        public int Id{get;set;} 
        public string District{get;set;} 
        public string Name{get;set;} 
        public string Status{get;set;}

    }

    public class District
    {
        public District(int Id, string Dist, string Name, string Status, List<Site> Sites)
        {
            this.Id = Id;
            this.Dist = Dist;
            this.Name = Name;
            this.Status = Status;
            this.Sites = Sites;
        }
        public int Id { get; set; }
        public string Dist{ get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public List<Site> Sites { get; set; }

    }

}