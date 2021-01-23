using System;

namespace OlimpusSN.Models
{
    public class Post : DbEntity
    {
        public string OwnerFirstName { get; set; }

        public string OwnerLasnName { get; set; }

        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public User User { get; set; }
    }
}