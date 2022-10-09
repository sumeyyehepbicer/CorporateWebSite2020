using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class UpdateHomePageRequestModel
    {
        public int Id { get; set; }
        public bool SliderVis { get; set; }
        public bool ServiceVis { get; set; }
        public bool BandVis { get; set; }
        public bool AboutVis { get; set; }
        public bool ProjectVis { get; set; }
        public bool NotifyVis { get; set; }
        public bool CommentVis { get; set; }
        public bool BlogVis { get; set; }
        public bool BrandVis { get; set; }
        public bool FooterVis { get; set; }
    }
}
