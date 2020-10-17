using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OlimpusSN.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, IdentityRole<long>, long>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }

        public DbSet<AppUser> UserAll { get; set; }

        public DbSet<PersonCommon> PersonCommon { get; set; }

        public DbSet<PersonHobbies> PersonHobbies { get; set; }

        public DbSet<PersonEducation> PersonEducation { get; set; }

        public DbSet<PersonEmployement> PersonEmployement { get; set; }

        public DbSet<PersonAll> PersonAll { get; set; }


        public DbSet<PersonContent> PersonContent { get; set; }

        public DbSet<AppUSer> FeedPost { get; set; }
    }
}
