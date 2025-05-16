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
        public async Task SeedAsync(UserManager<User> userManager)
        {
            if(userManager.Users.Any())
            {
                return; // DB has been seeded
            }

            var admin = new User
            {
                Email = "pavlingeorgiev2002@gmail.com",
                UserName = "pavlingeorgiev2002@gmail.com",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin",
                DateOfBirth = new DateOnly(2001, 1, 1),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var password = "Admin123.";

            var result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, Enums.UserRole.Admin.ToString());
            }
        }
            
    }
}
