using Microsoft.EntityFrameworkCore;

namespace OlimpusSN.Models
{
    public class OlympusDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<PersonAll> PersonAll { get; set; }

        public DbSet<PersonCommon> PersonCommon { get; set; }

        public DbSet<PersonHobbies> PersonHobbies { get; set; }

        public DbSet<PersonEducation> PersonEducation { get; set; }

        public DbSet<PersonEmployement> PersonEmployement { get; set; }

        public DbSet<Post> Posts { get; set; }

        public OlympusDbContext(DbContextOptions<OlympusDbContext> options)
            : base(options) { }
    }
}
