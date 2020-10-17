using System;

namespace OlimpusSN.Models
{
    public class PersonContent
    {
        public long Id { get; set; }

        public AppUSer FeedPost { get; set; }
    }

    public class AppUSer
    {
        public long Id { get; set; }

        public string OwnerFirstName { get; set; }

        public string OwnerLasnName { get; set; }

        public DateTime PostDate { get; set; }

        public string Content { get; set; }
    }
}
