using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class CustomInfo:BaseEntity
    {
        public string BgImageUrl { get; set; }
        public string Icon { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }

    }
}
