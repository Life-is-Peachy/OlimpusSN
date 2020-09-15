namespace OlimpusSN.Models
{
    public class PersonSummary
    {
        public long Id { get; set; }


        public long InfoCommonId { get; set; }
        public InfoCommon InfoCommon { get; set; }

        public long InfoHobbiesId { get; set; }
        public InfoHobbies InfoHobbies { get; set; }

        public long InfoEducationId { get; set; }
        public InfoEducation InfoEducation { get; set; }

        public long InfoEmployementId { get; set; }
        public InfoEmployement InfoEmployement { get; set; }
    }

    public class InfoCommon
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

    public class InfoHobbies
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

    public class InfoEducation
    {
        public long Id { get; set; }

        public string WhereEducated { get; set; }

        public string PeriodOfEducation { get; set; }

        public string Description { get; set; }
    }

    public class InfoEmployement
    {
        public long Id { get; set; }

        public string WhereEmployemented { get; set; }

        public string PeriodOfEmployement { get; set; }

        public string Description { get; set; }
    }
}
