using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class Project:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public string Year { get; set; }
        //public string Location { get; set; }
        //public string Sector { get; set; }
        //public string Technology { get; set; }
        //public string Price { get; set; }
    }
}
