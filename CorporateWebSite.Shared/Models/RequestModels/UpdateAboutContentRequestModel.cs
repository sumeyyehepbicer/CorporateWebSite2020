using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class UpdateAboutContentRequestModel
    {
        public int Id { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
    }
}
