namespace OlimpusSN.Models
{
    public class PersonAll : DbEntity
    {
        public PersonCommon PersonCommon { get; set; }

        public PersonHobbies PersonHobbies { get; set; }

        public PersonEducation PersonEducation { get; set; }

        public PersonEmployement PersonEmployement { get; set; }
    }
}
