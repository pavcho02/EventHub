using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeders
{
    public class UserRolesSeeder
    {
        public async Task SeedAsync(EventHubDbContext context)
        {
            if (context.Roles.Any())
            {
                return; // DB has been seeded
            }

            var roles = new List<Models.UserRole>()
            {
                new Models.UserRole{Name="Admin",NormalizedName="ADMIN", RoleType = Enums.UserRole.Admin},
                new Models.UserRole{Name="EventOrganizer", NormalizedName= "EVENTORGANIZER", 
                    RoleType = Enums.UserRole.EventOrganizer},
                new Models.UserRole{Name="User",NormalizedName="USER", RoleType = Enums.UserRole.User},
            };

            foreach (var role in roles)
            {
                await context.Roles.AddAsync(role);
            }

            await context.SaveChangesAsync();
        }
    }
}
