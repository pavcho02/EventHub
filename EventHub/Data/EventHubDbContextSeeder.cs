using Data.Models;
using Data.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EventHubDbContextSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<UserRole> roleManager;
        private readonly EventHubDbContext context;
       public EventHubDbContextSeeder(EventHubDbContext context, UserManager<User> userManager,
            RoleManager<UserRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            await new UserRolesSeeder().SeedAsync(roleManager);
            await new UserSeeder().SeedAsync(userManager);            
        }
        
    }
}
