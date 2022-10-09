using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class Menu:BaseEntity
    {
        public string Name { get; set; }
        public string ToLink { get; set; }    
    }

}
