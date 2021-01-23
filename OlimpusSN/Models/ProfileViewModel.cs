using System;
using System.Collections.Generic;

namespace OlimpusSN.Models
{
    public class ProfileViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Post> ListPosts { get; set; }
    }
}
