using System;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPostRepository
    {
        void CreatePost(Post post, long id);
        ProfileViewModel GetPost(long id);
    }


    public class PostRepository : IPostRepository
    {
        private OlympusDbContext _context;

        public PostRepository(OlympusDbContext ctx) 
            => _context = ctx; 


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

        public ProfileViewModel GetPost(long id)
        {
            ProfileViewModel viewModel = new ProfileViewModel
            {
                Post = default,
                ListPosts = _context.Posts.Where(x => x.User.Id == id)
            };

            return viewModel;
        }

        private User GetUser(long id)
            => _context.Users.FirstOrDefault(x => x.Id == id);
    }
}
