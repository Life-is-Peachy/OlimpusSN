namespace OlimpusSN.Models
{
    public class UserPersonalInfo
    {
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

    public class PersonalInfoViewModel
    {

    }
}
