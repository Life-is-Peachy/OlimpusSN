namespace OlimpusSN.Models
{
    public class PersonAll
    {
        public long Id { get; set; }

        public PersonCommon PersonCommon { get; set; }

        public PersonHobbies PersonHobbies { get; set; }

        public PersonCareer PersonCareer { get; set; }
    }

    public class PersonCommon
    {
        public long Id { get; set; }

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

    public class PersonHobbies
    {
        public long Id { get; set; }

        public string Hobbies { get; set; }

        public string FavMusic { get; set; }

        public string FavTV { get; set; }

        public string FavBooks { get; set; }

        public string FavMovies { get; set; }

        public string FavWriters { get; set; }

        public string FavGames { get; set; }

        public string OtherInterests { get; set; }
    }

    public class PersonEducation
    {
        public long Id { get; set; }

        public string WhereEducated { get; set; }

        public string PeriodOfEducation { get; set; }

        public string Description { get; set; }
    }

    public class PersonEmployement
    {
        public long Id { get; set; }

        public string WhereEmployemented { get; set; }

        public string PeriodOfEmployement { get; set; }

        public string Description { get; set; }
    }

    public class PersonCareer
    {
        public long Id { get; set; }

        public PersonEducation PersonEducation { get; set; }

        public PersonEmployement PersonEmployement { get; set; }
    }
}
