namespace OlimpusSN.Models
{
    public class PersonEducation : DbEntity
    {
        public string WhereEducated { get; set; }

        public string PeriodOfEducation { get; set; }

        public string Description { get; set; }
    }
}
