using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public int ParentId { get; set; } = 0;
        public bool IsEmailVerification { get; set; }
        public bool IsSmsVerification { get; set; }
        public string Role { get; set; }
    }
}
