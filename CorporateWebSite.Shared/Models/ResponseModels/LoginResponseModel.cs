using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.ResponseModels
{
    public class LoginResponseModel
    {

        public string Token { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
