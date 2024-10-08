using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTracker.Data;
using TheBugTracker.Models;
using TheBugTracker.Services;
using TheBugTracker.Services.Factories;
using TheBugTracker.Services.Interfaces;

namespace TheBugTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(DataUtility.GetConnectionString(Configuration),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddDatabaseDeveloperPageExceptionFilter();

            //Changed to AddIdentity from AddDefaultIdentity
            //AddIdentity registers the specified user and role types with the services
            //but doesn�t bring in UI-related services and configurations found in default version so we add manually.
            //Set the parameters as BTUser and IdentityRole:
            //BTUser: Specifies the type to be used for users in the Identity system. It's your custom user class.
            //IdentityRole: Specifies the type to be used for roles in the Identity system.
            //Will touch on IdentityRole later
            services.AddIdentity<BTUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                //Following two lines added:
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                //Following principle factory added
                .AddClaimsPrincipalFactory<BTUserClaimsPrincipalFactory>();

            //Registering Custom Services (necessary for dependency injections)
            services.AddScoped<IBTRolesService, BTRolesService>();
            services.AddScoped<IBTCompanyInfoService, BTCompanyInfoService>();
            services.AddScoped<IBTProjectService, BTProjectService>();
            services.AddScoped<IBTTicketService, BTTicketService>();
            services.AddScoped<IBTTicketHistoryService, BTTicketHistoryService>();
            services.AddScoped<IBTNotificationService, BTNotificationService>();
            services.AddScoped<IBTInviteService, BTInviteService>();
            services.AddScoped<IBTFileService, BTFileService>();
            services.AddScoped<IBTLookupService, BTLookupService>();

            services.AddScoped<IEmailSender, BTEmailService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
