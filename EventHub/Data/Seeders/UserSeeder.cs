using Data.Enums;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeders
{
    public class UserSeeder
    {
        public async Task SeedAsync(EventHubDbContext context)
        {
            if(context.Users.Any())
            {
                return; // DB has been seeded
            }

            var admin = new User
            {
                Email = "pavlingeorgiev2002@gmail.com",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "Admin123.");

            await context.UserRoles.AddAsync(new IdentityUserRole<string>()
            {
                UserId = admin.Id,
                RoleId = context.Roles.FirstOrDefault(x => x.Name == "Admin").Id
            });
        }
            
    }
}
