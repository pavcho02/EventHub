using Business;
using Data;
using Data.Models;
using EventHub.Common.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventHub
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EventHubDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });

            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;

            }).AddRoles<UserRole>().AddEntityFrameworkStores<EventHubDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.Configuration);

            services.AddTransient<IEventReportBusiness, EventReportBusiness>();
            services.AddTransient<IEventBusiness, EventBusiness>();
            services.AddTransient<IEventReviewBusiness, EventReviewBusiness>();
            services.AddTransient<IRoleRequestBusiness, RoleRequestBusiness>();
            services.AddTransient<IParticipationBusiness, ParticipationBusiness>();

            services.AddTransient<IMapper, Mapper>();


            services.AddTransient<IEmailSender>(x => new EmailSender(
                Configuration.GetSection("SendGridEmailSender")["APIKey"],
                Configuration.GetSection("SendGridEmailSender")["Sender"],
                Configuration.GetSection("SendGridEmailSender")["SenderName"]));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Seed data during startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var context = services.GetRequiredService<EventHubDbContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<UserRole>>();

                // Run seeders
                new EventHubDbContextSeeder(context, userManager, roleManager).SeedAsync().GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");                
                endpoints.MapRazorPages();
            });
        }
    }
}
