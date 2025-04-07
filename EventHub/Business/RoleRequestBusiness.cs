using Data;
using Data.Enums;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RoleRequestBusiness : IRoleRequestBusiness
    {
        private readonly EventHubDbContext context;
        private readonly UserManager<User> userManager;
        private readonly IEmailSender emailSender;

        public RoleRequestBusiness(EventHubDbContext context, UserManager<User> userManager, IEmailSender emailSender)
        {
            this.context = context;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        public async Task RequestRoleChangeAsync(string userId, string description)
        {
            if (await context.Users.FindAsync(userId) != null)
            {

                var roleRequest = new RoleRequest
                {
                    UserId = userId,
                    Description = description
                };
                context.RoleRequests.Add(roleRequest);
                await context.SaveChangesAsync();
            }
        }

        public async Task ApproveRoleChangeAsync(string userId)
        {
            var roleRequest = await context.RoleRequests.FindAsync(userId);
            if (roleRequest != null)
            {
                // Update the user's role in the database
                var user = await context.Users.FindAsync(userId);
                if (user != null)
                {
                    await userManager.RemoveFromRoleAsync(user, Data.Enums.UserRole.User.ToString());
                    await userManager.AddToRoleAsync(user, Data.Enums.UserRole.EventOrganizer.ToString());
                    await emailSender.SendEmailForAccountRoleChangeAsync(user.Email);
                }

                context.RoleRequests.Remove(roleRequest);
                await context.SaveChangesAsync();
            }
        }

        public async Task RejectRoleChangeAsync(string userId)
        {
            var roleRequest = await context.RoleRequests.FindAsync(userId);
            if (roleRequest != null)
            {
                context.RoleRequests.Remove(roleRequest);
                await context.SaveChangesAsync();
            }
        }
    }
}
