using System;

namespace OlimpusSN.Models
{
    public class PersonCommon : DbEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public Genders Gender { get; set; }

        public string WebSite { get; set; }

        public string PhoneNumber { get; set; }

        public Countries Country { get; set; }

        public string AboutMe { get; set; }

        public string Birthplace { get; set; }

        public string Occupation { get; set; }

        public Married Married { get; set; }

        public string Political { get; set; }

        public string Religious { get; set; }
    }
}
