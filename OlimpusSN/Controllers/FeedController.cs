using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlimpusSN.Models;

namespace OlimpusSN.Controllers
{
    public class FeedController : Controller
    {
        private OlympusDbContext _context;

        public long UserId => GetId(HttpContext.User.Identity.Name);

        private IPostRepository _postRepository;

        public FeedController(IPostRepository post, OlympusDbContext ctx)
        {
            _postRepository = post;
            _context = ctx;
        }


        public IActionResult Newsfeed()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Post(Post post)
        {
            post.OwnerFirstName = _context.Users.First(x => x.ID == UserId).FirstName;
            post.OwnerLasnName = _context.Users.First(x => x.ID == UserId).LastName;
            post.PostDate = DateTime.Now;
            post.User = _context.Users.First(x => x.ID == UserId);

            _postRepository.CreatePost(post);
            return RedirectToAction(nameof(Newsfeed));

        }

        private long GetId(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email).ID;
        }
    }
}
