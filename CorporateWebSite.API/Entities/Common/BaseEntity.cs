using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
