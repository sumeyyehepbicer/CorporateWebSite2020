using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class SendMessageRequestModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
