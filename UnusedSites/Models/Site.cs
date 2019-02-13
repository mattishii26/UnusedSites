using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//Model for the site objects
namespace UnusedSites.Models{
    public class Site{
        public Site(int Id, string District, string Name, string Status, double NumAcres, int MonthLastUsed, int YearLastUsed, double PurchasePrice,
            double AppraisedValue, int MonthAppraised, int YearAppraised, double CurrentValue, string GradeLevel,string Changes, string Reason, string Approved)
        {
            this.Id = Id;
            this.District = District;
            this.Name = Name;
            this.Status = Status;
            this.NumAcres = NumAcres;
            this.MonthLastUsed = MonthLastUsed;
            this.YearLastUsed = YearLastUsed;
            this.PurchasePrice = PurchasePrice;
            //this.MonthAcquired = MonthAcquired;
            this.AppraisedValue = AppraisedValue;
            this.MonthAppraised = MonthAppraised;
            this.YearAppraised = YearAppraised;
            this.CurrentValue = CurrentValue;
            this.GradeLevel = GradeLevel;
            this.Changes = Changes;
            this.Reason = Reason;
            this.Approved = Approved;
            //this.YearsHeld = YearsHeld;
        } 
        public int Id{get;set;} 
        public string District{get;set;} 
        public string Name{get;set;} 
        public string Status{get;set;}
        public double NumAcres { get; set; }
        public int MonthLastUsed { get; set; }
        public int YearLastUsed { get; set; }
        public double PurchasePrice { get; set; }
        //public int MonthAcquired { get; set; }
        public double AppraisedValue { get; set; }
        public int MonthAppraised { get; set; }
        public int YearAppraised { get; set; }
        public double CurrentValue { get; set; }
        public string GradeLevel { get; set; }
        public string Changes { get; set; }
        public string Reason { get; set; }
        public string Approved {get; set;}


        //public int YearsHeld { get; set; }

    }

    public class District
    {
        public District(int Id, string Name, string Contact_Salt, string Contact_FName, string Contact_LName,
            string Contact_PNumber, string Date_Sent, string Date_Received, string From424_Rec_Date, List<Site> Sites)
        {
            this.Id = Id;
            //this.Dist = Dist;
            this.Name = Name;
            //this.Status = Status;
            this.Contact_Salt = Contact_Salt;
            this.Contact_FName = Contact_FName;
            this.Contact_LName = Contact_LName;
            this.Contact_PNumber = Contact_PNumber;
            this.Date_Sent = Date_Sent;
            this.Date_Received = Date_Received;
            this.From424_Rec_Date = From424_Rec_Date;
            this.Sites = Sites;
        }
        public int Id { get; set; }
        public string Dist { get; set; }
        public string Name { get; set; }
        //public string Status { get; set; }
        public string StatContact_Saltus { get; set; }
        public string Contact_Salt { get; set; }
        public string Contact_FName { get; set; }
        public string Contact_LName { get; set; }
        public string Contact_PNumber { get; set; }
        public string Date_Sent { get; set; }
        public string Date_Received { get; set; }
        public string From424_Rec_Date { get; set; }

        public List<Site> Sites { get; set; }

    }
}