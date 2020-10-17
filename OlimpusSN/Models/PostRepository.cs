using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPostRepository
    {
        void CreatePost(AppUser post);

        AppUser GetUser(long id);
    }


    public class PostRepository : IPostRepository
    {
        private AppIdentityDbContext _context;


        public PostRepository(AppIdentityDbContext ctx) => _context = ctx;


        public void CreatePost(AppUser post)
        {
            
            _context.Update(post);
            _context.SaveChanges();
        }


        public AppUser GetUser(long id)
        {
            return _context.UserAll
                .Include(i => i.PersonAll)
                .ThenInclude(o => o.PersonCommon)
                .Include(u => u.PersonContent)
                .ThenInclude(a => a.FeedPost)
                .First(e => e.Id == id);
        }
    }
}
