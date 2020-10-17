using System;
using System.Text;

namespace OlimpusSN.Models
{
    public static class SeedData
    {
        public static PersonAll SeedOnRegister() => InitialPersonAll;


        public static string GenName()
        {
            int Length = 10;
            string Alphabet = "qwertyuiopasdfghjklzxcvbnm";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;
            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);

            }
            return sb.ToString();
        }


        private static PersonAll InitialPersonAll
        {
            get
            {
                PersonCommon pc = new PersonCommon
                {
                    FirstName = "Не указано",
                    LastName = "Не указано",
                    Email = "Не указано",
                    Birthday = DateTime.Now,
                    Gender = Genders.Male,
                    WebSite = "Не указано",
                    PhoneNumber = "Не указано",
                    Country = Countries.USA,
                    AboutMe = "Не указано",
                    Birthplace = "Не указано",
                    Occupation = "Не указано",
                    Married = Married.Single,
                    Political = "Не указано",
                    Religious = "Не указано"
                };
                PersonHobbies ph = new PersonHobbies
                {
                    Hobbies = "Не указано",
                    FavMusic = "Не указано",
                    FavTV = "Не указано",
                    FavBooks = "Не указано",
                    FavMovies = "Не указано",
                    FavWriters = "Не указано",
                    FavGames = "Не указано",
                    OtherInterests = "Не указано"
                };
                PersonEducation pu = new PersonEducation
                {
                    WhereEducated = "Не указано",
                    PeriodOfEducation = "Не указано",
                    Description = "Не указано"
                };
                PersonEmployement pe = new PersonEmployement
                {
                    WhereEmployemented = "Не указано",
                    PeriodOfEmployement = "Не указано",
                    Description = "Не указано"
                };
                
                PersonAll pA = new PersonAll
                {
                    PersonCommon = pc,
                    PersonHobbies = ph,
                    PersonEducation = pu,
                    PersonEmployement = pe
                };
                return pA;
            }
        }


        private static AppUser User
        {
            get
            {
                PersonCommon pc = new PersonCommon
                {
                    WebSite = "www.kink.com",
                    PhoneNumber = "555-444-777",
                    Country = Countries.USA,
                    AboutMe = "Lube it up",
                    Birthplace = "Japan",
                    Occupation = "smth",
                    Married = Married.Single,
                    Political = "Fistin",
                    Religious = "Dungeons"
                };
                PersonHobbies ph = new PersonHobbies
                {
                    Hobbies = "Slaves",
                    FavMusic = "rock",
                    FavTV = "nico-nico",
                    FavBooks = "nvm",
                    FavMovies = "Play with fire 2",
                    FavWriters = "anyth",
                    FavGames = "Masters",
                    OtherInterests = "anything"
                };
                PersonEducation pu = new PersonEducation
                {
                    WhereEducated = "LA",
                    PeriodOfEducation = "1 - 3",
                    Description = "NVM"
                };
                PersonEmployement pe = new PersonEmployement
                {
                    WhereEmployemented = "SF",
                    PeriodOfEmployement = "1-5",
                    Description = "Oh my"
                };
                PersonAll pA = new PersonAll
                {
                    PersonCommon = pc,
                    PersonHobbies = ph,
                    PersonEducation = pu,
                    PersonEmployement = pe
                };
                AppUser user = new AppUser
                {
                    UserName = "Van",
                    Email = "Van@gmail.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEB2uJKWxQVfSJ4QeHlytQl+dwcw6D4mx5v2R2+EUPIn/vj6G5qoMRXiG0IhiUr/2HA==",
                    PersonAll = pA
                };
                return user;
            }
        }
    }
}
