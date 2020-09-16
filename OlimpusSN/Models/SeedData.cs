using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace OlimpusSN.Models
{
    public static class SeedData
    {
        public static void Seed(DbContext context)
        {
            if (context is AppIdentityDbContext users && users.User.Count() == 0)
                users.User.Add(User);

            context.SaveChanges();
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
                    PersonEducation = pu,
                    PersonHobbies = ph,
                    PersonEmployement = pe
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
