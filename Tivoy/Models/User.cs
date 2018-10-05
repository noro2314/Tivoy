using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tivoy.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset DOB { get; set; }
        public int? GenderID { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }
}
