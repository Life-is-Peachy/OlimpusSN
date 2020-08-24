using Microsoft.AspNetCore.Identity;
using System;

namespace OlimpusSN.Models
{
    public class AppUser : IdentityUser
    {
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Genders Gender { get; set; }
    }
}
