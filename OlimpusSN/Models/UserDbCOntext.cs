using Microsoft.EntityFrameworkCore;

namespace OlimpusSN.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }

        public DbSet<PersonAll> PersonAll { get; set; }
    }
}
