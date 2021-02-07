using System;
using System.Linq;
using System.Collections.Generic;

namespace OlimpusSN.Models
{
    public interface IPostRepository
    {
        void CreatePost(Post post, long id);
        void EditPost(Post post, long id);
        void DeletePost(long id);
        IEnumerable<Post> GetPost(long id);
    }


    public class PostRepository : IPostRepository
    {
        private readonly OlympusDbContext _context;

        public PostRepository(OlympusDbContext ctx) => _context = ctx; 


        public void CreatePost(Post post, long id)
        {
            User user = GetUser(id);

            post.OwnerFirstName = user.FirstName;
            post.OwnerLasnName = user.LastName;
            post.PostDate = DateTime.Now;
            post.User = user;

            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void EditPost(Post post, long id)
        {
            User user = GetUser(id);

            post.OwnerFirstName = user.FirstName;
            post.OwnerLasnName = user.LastName;
            post.PostDate = DateTime.Now;
            post.User = user;

            _context.Posts.Update(post);
            _context.SaveChanges();
        }


        public IEnumerable<Post> GetPost(long id)
        {
            return _context.Posts.Where(x => x.User.Id == id);
        }


        public void DeletePost(long id)
        {
            _context.Posts.Remove(_context.Posts.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }

        private User GetUser(long id)
            => _context.Users.FirstOrDefault(x => x.Id == id);
    }
}
