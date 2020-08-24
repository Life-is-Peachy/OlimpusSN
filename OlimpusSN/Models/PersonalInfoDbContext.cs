using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpusSN.Models
{
    public class PersonalInfoDbContext : DbContext
    {
        public DbSet<UserPersonalInfo> MyProperty { get; set; }
    }
}
