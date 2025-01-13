using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class UserRole : IdentityRole
    {
        public Enums.UserRole RoleType { get; set; }
    }
}
