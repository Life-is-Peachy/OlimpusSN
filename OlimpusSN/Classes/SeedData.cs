using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace OlimpusSN.Models
{
    public static class SeedData
    {
        public static PersonAll SeedOnRegister(params object[] person)
        {
            InitialPersonAll.PersonCommon.FirstName = (string)person[0];
            InitialPersonAll.PersonCommon.LastName = (string)person[1];
            InitialPersonAll.PersonCommon.Email = (string)person[2];
            InitialPersonAll.PersonCommon.Birthday = (DateTime)person[3];
            InitialPersonAll.PersonCommon.Gender = (Genders)person[4];

            return InitialPersonAll;
        }
        public static void InitialDb(IServiceProvider appBuilder)
        {
            OlympusDbContext OlympusDb = appBuilder.GetRequiredService<OlympusDbContext>();
            if (!OlympusDb.Users.Any())
            {
                OlympusDb.Users.Add(User);
                OlympusDb.SaveChanges();
            }
        }


        private static PersonAll InitialPersonAll
        {
            get
            {
                PersonCommon pc = new PersonCommon
                {
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


        private static User User
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
                User user = new User
                {
                    Email = "Bozya603@gmail.com",
                    Password = "Sparkmedia123$",
                    FirstName = "Sergey",
                    LastName = "Ivanin",
                    Birthday = new DateTime(1998, 01, 12),
                    Gender = Genders.Male,
                    PersonAll = pA
                };

                return user;
            }
        }
    }
}
