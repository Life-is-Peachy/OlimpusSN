using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OlimpusSN.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }

        public DbSet<AppUser> UserAll { get; set; }
        public DbSet<PersonCommon> PersonCommon { get; set; }
        public DbSet<PersonHobbies> PersonHobbies { get; set; }
        public DbSet<PersonEducation> PersonEducation { get; set; }
        public DbSet<PersonEmployement> PersonEmployement { get; set; }

    }
}
