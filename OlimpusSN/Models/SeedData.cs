using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace OlimpusSN.Models
{
    public static class SeedData
    {
        public static void Seed(DbContext context)
        {
            if (context is AppIdentityDbContext users && users.UserAll.Count() == 0)
                users.UserAll.Add(User);
            context.SaveChanges();
        }

        public static PersonAll SeedOnRegister() => InitialPersonAll;

        private static PersonAll InitialPersonAll
        {
            get
            {
                PersonCommon pc = new PersonCommon
                {
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
                PersonCareer pCr = new PersonCareer
                {
                    PersonEducation = pu,
                    PersonEmployement = pe
                };
                PersonAll pA = new PersonAll
                {
                    PersonCommon = pc,
                    PersonHobbies = ph,
                    PersonCareer = pCr
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
                PersonCareer pCr = new PersonCareer
                {
                    PersonEducation = pu,
                    PersonEmployement = pe
                };
                PersonAll pA = new PersonAll
                {
                    PersonCommon = pc,
                    PersonHobbies = ph,
                    PersonCareer = pCr
                };
                AppUser user = new AppUser
                {
                    UserName = "Van",
                    LastName = "Darkholme",
                    Email = "Van@gmail.com",
                    Birthday = DateTime.Now,
                    Gender = Genders.Male,
                    PasswordHash = "AQAAAAEAACcQAAAAEB2uJKWxQVfSJ4QeHlytQl+dwcw6D4mx5v2R2+EUPIn/vj6G5qoMRXiG0IhiUr/2HA==",
                    PersonAll = pA
                };
                return user;
            }
        }
    }
}
