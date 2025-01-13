using Data.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class EventHubDbContextSeeder
    {
        private readonly EventHubDbContext context;
        public EventHubDbContextSeeder(EventHubDbContext context)
        {
            this.context = context;
        }
        public async Task SeedAsync()
        {
            if (context.Database.EnsureCreated())
            {
                await new UserRolesSeeder().SeedAsync(context);
                await new UserSeeder().SeedAsync(context);
            }
        }
        
    }
}
