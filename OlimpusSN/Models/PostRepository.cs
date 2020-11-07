using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPostRepository
    {
        void CreatePost(Post post);

        IEnumerable<Post> GetPost(long id);
    }

    public class PostRepository : IPostRepository
    {
        private OlympusDbContext _context;

        public PostRepository(OlympusDbContext ctx) => _context = ctx;


        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }


        public IEnumerable<Post> GetPost(long id)
        {
            return _context.Posts.Where(x => x.User.ID == id);
        }
    }
}
