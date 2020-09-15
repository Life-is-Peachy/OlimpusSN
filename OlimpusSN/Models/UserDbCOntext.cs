using Microsoft.EntityFrameworkCore;

namespace OlimpusSN.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }

        public DbSet<InfoCommon> InfoCommon { get; set; }

        public DbSet<InfoHobbies> InfoHobbies { get; set; }

        public DbSet<InfoEducation> InfoEducation { get; set; }

        public DbSet<InfoEmployement> InfoEmployement { get; set; }

        public DbSet<PersonSummary> InfoSummary { get; set; }
    }
}
