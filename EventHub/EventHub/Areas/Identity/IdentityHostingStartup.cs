[assembly: HostingStartup(typeof(EventHub.Areas.Identity.IdentityHostingStartup))]

namespace EventHub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
