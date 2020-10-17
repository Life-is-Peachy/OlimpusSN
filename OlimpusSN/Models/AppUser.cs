using Microsoft.AspNetCore.Identity;

namespace OlimpusSN.Models
{
    public class AppUser : IdentityUser<long>
    {
        public PersonAll PersonAll { get; set; }

        public PersonContent PersonContent { get; set; }
    }
}
