
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Quoting
{
    public class QuoteBenefiriariesModel
    {
        public int EntityID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Relation { get; set; }
        public int RelationID { get; set; }
        public string IDNumber { get; set; }
        public Nullable<decimal> CoveredAmount { get; set; }
        public Nullable<decimal> Allocation { get; set; }
        public string DateCeded { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Status { get; set; }
    }




    public class QuoteEntitiesList
    {
        public int EntityID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Relation { get; set; }
        public int RelationID { get; set; }
        public string IDNumber { get; set; }
        public Nullable<decimal> CoveredAmount { get; set; }
        public Nullable<decimal> Allocation { get; set; }
        public Nullable<System.DateTime> DateCeded { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Status { get; set; }
    }
}


