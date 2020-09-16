using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpusSN.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IPersonRepository _repository;
        private SignInManager<AppUser> signInManager;

        public ProfileController(SignInManager<AppUser> sgnMgr, IPersonRepository repo)
        {
            signInManager = sgnMgr;
            _repository = repo;
        }

        public IActionResult ProfileAbout() => View();

        public IActionResult ProfilePage() => View();

        public IActionResult Newsfeed() => View();

        public IActionResult PersonalInformation()
        {
            string userId = signInManager.UserManager.GetUserId(User);
            return View(_repository.GetUser(userId));
        }


        [HttpPost]
        public IActionResult SavePersonInfo(AppUser person)
        {
            _repository.SavePersonInfo(person);
            return View(nameof(ProfileAbout));
        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(ProfilePage));
        }
    }
}
