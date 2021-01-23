using System;

namespace OlimpusSN.Models
{
    public class User : DbEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Genders Gender { get; set; }

        public PersonAll PersonAll { get; set; }
    }
}