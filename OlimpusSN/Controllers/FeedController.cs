using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;

namespace OlimpusSN.Controllers
{
    public class FeedController : Controller
    {
        private readonly IPostRepository _postRepository;

        public FeedController(IPostRepository post) => _postRepository = post;



        [HttpPost]
        public ActionResult Post(Post post, bool isEdit = false)
        {
            if (!isEdit)
            {
                _postRepository.CreatePost(post, this.GetId());
                return RedirectToAction("Profile", "Profile");
            }

            _postRepository.EditPost(post, this.GetId());
            return RedirectToAction("Profile", "Profile");
        }

        public ActionResult Delete(long id)
        {
            _postRepository.DeletePost(id);

            return RedirectToAction("Profile", "Profile");
        }


        public ActionResult Edit(long id, string content)
        {
            return View(new Post { Id = id, Content = content });
        }
    }
}
