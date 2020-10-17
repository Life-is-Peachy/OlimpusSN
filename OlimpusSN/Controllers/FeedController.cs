using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;

namespace OlimpusSN.Controllers
{
    public class FeedController : Controller
    {
        private IPostRepository _postRepository;

        public long UserId => Convert.ToInt64(signInManager.UserManager.GetUserId(User));

        private readonly SignInManager<AppUser> signInManager;

        public FeedController(IPostRepository post, SignInManager<AppUser> sgnMgr)
        {
            _postRepository = post;
            signInManager = sgnMgr;
        }


        public IActionResult Newsfeed()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Post(AppUser post)
        {
            post.Id = UserId;
            _postRepository.CreatePost(post);
            return RedirectToAction(nameof(Newsfeed));
        }


    }
}
