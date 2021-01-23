using System;

namespace OlimpusSN.Models
{
    public class Photografy : DbEntity
    {
        public DateTime UploadDate { get; set; }

        public string Name { get; set; }

        public User User { get; set; }
    }
}
