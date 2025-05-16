using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeders
{
    public class UserRolesSeeder
    {
        public async Task SeedAsync(RoleManager<UserRole> roleManager)
        {
            if (roleManager.Roles.Any())
            {
                return; // DB has been seeded
            }

            var roles = new List<UserRole>()
            {
                new UserRole{Name="Admin",NormalizedName="ADMIN", RoleType = Enums.UserRole.Admin},
                new UserRole{Name="EventOrganizer", NormalizedName= "EVENTORGANIZER", 
                    RoleType = Enums.UserRole.EventOrganizer},
                new UserRole{Name="User",NormalizedName="USER", RoleType = Enums.UserRole.User},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}
