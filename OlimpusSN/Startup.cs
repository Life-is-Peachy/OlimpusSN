using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OlimpusSN.Models;

namespace OlimpusSN
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
                Configuration["Data:ConnectionStrings:Identity"]));


            services.AddTransient<IPersonRepository<PersonAll>, PersonRepository<PersonAll>>();
            services.AddTransient<IPersonRepository<PersonHobbies>, PersonRepository<PersonHobbies>>();
            services.AddTransient<IPersonRepository<PersonCommon>, PersonRepository<PersonCommon>>();
            services.AddTransient<IPersonRepository<PersonEducation>, PersonRepository<PersonEducation>>();
            services.AddTransient<IPersonRepository<PersonEmployement>, PersonRepository<PersonEmployement>>();

            services.AddTransient<IPostRepository, PostRepository>();

            services.AddIdentity<AppUser, IdentityRole<long>>()
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
                    pattern: "{controller=Feed}/{action=Newsfeed}/{id?}");
            });
        }
    }
}
