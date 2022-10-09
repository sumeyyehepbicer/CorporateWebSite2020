using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class Contact:BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
