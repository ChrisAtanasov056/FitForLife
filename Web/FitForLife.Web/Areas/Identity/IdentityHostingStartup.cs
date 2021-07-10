using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FitForLife.Areas.Identity.IdentityHostingStartup))]
namespace FitForLife.Areas.Identity
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
