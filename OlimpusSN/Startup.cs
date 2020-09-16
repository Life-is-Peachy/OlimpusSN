using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OlimpusSN.Models;
using Microsoft.AspNetCore.Http;

namespace OlimpusSN
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
                       

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
                Configuration["Data:ConnectionStrings:Identity"]));
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(
                Configuration["Data:ConnectionStrings:User"]));

            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonCommonRepository, PersonCommonRepository>();
            services.AddTransient<IPersonHobbiesRepository, PersonHobbiesRepository>();



            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.ConfigureApplicationCookie(opts => { opts.LoginPath = "/Account/Register"; });

            services.AddControllersWithViews();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppIdentityDbContext ctx)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Profile}/{action=PersonCommon}/{id?}");
            });
            SeedData.Seed(ctx);
        }
    }
}
