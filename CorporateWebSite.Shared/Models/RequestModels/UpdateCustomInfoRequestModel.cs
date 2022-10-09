using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class UpdateCustomInfoRequestModel
    {
        public int Id { get; set; }
        public string BgImageUrl { get; set; }
        public string Icon { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }
        public bool IsActive { get; set; }

    }
}
