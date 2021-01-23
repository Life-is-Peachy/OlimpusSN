using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;

namespace OlimpusSN.Controllers
{
    public class FeedController : Controller
    {
        private IPostRepository _postRepository;

        public FeedController(IPostRepository post)
            => _postRepository = post;



        [HttpPost]
        public ActionResult Post(Post post)
        {
            _postRepository.CreatePost(post, this.GetId());

            return RedirectToAction("Profile", "Profile");
        }
    }
}
