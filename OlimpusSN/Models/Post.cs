using System;
using System.Collections.Generic;

namespace OlimpusSN.Models
{
    public class Post
    {
        public long Id { get; set; }

        public string OwnerFirstName { get; set; }

        public string OwnerLasnName { get; set; }

        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public User User { get; set; }
    }
}