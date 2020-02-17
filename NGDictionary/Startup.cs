using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NGDictionary.Database;
using NGDictionary.Database.Entity;
using NGDictionary.Database.Interfaces;
using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Database.Repositories;
using NGDictionary.Services;
using NGDictionary.Services.Helpers;
using NGDictionary.Services.Interfaces;
using NGDictionary.Services.Interfaces.Helpers;

namespace NGDictionary
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
            services.AddControllersWithViews();
            // https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-3.1
            // https://www.domstamand.com/secure-your-angularasp-net-core-application-with-anti-forgery-token/
            // Antiforgery token automatically added with call:
            // MapControllerRoute or AddMvc or MapRazorPages or MapBlazorHub
            //services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            services.AddDbContext<EFDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // add identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EFDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDictionaryRepository, DictionaryRepository>();
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
