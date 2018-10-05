using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tivoy.Models
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
        }
        public Role(string roleName) : base(roleName)
        {
        }
    }
}
