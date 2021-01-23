namespace OlimpusSN.Models
{
    public class PersonHobbies : DbEntity
    {
        public string Hobbies { get; set; }

        public string FavMusic { get; set; }

        public string FavTV { get; set; }

        public string FavBooks { get; set; }

        public string FavMovies { get; set; }

        public string FavWriters { get; set; }

        public string FavGames { get; set; }

        public string OtherInterests { get; set; }
    }
}
