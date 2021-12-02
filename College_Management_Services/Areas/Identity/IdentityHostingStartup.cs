using System;
using College_Management_Services.Areas.Identity.Data;
using College_Management_Services.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(College_Management_Services.Areas.Identity.IdentityHostingStartup))]
namespace College_Management_Services.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginRegisterContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LoginRegisterContextConnection")));

                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                //    .AddEntityFrameworkStores<LoginRegisterContext>();
            });
        }
    }
}