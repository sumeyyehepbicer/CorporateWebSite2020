using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class LoginRequestModel
    {
        public string LoginKey { get; set; }
        public string Password { get; set; }
    }
}
