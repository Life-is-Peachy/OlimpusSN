using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using OlimpusSN.Models;
using System;

namespace OlimpusSN
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OlympusDbContext>(options => options.UseSqlServer(
               Configuration["Data:ConnectionStrings:OlympusSN"]));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/SignIn");
                });


            services.AddTransient<IPersonRepository<PersonAll>, PersonRepository<PersonAll>>();
            services.AddTransient<IPersonRepository<PersonHobbies>, PersonRepository<PersonHobbies>>();
            services.AddTransient<IPersonRepository<PersonCommon>, PersonRepository<PersonCommon>>();
            services.AddTransient<IPersonRepository<PersonEducation>, PersonRepository<PersonEducation>>();
            services.AddTransient<IPersonRepository<PersonEmployement>, PersonRepository<PersonEmployement>>();

            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPhotoRepository, PhotoRepository>();


            services.AddControllersWithViews();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Profile", action = "Profile" });
            });

            SeedData.InitialDb(serviceProvider);
        }
    }
}
