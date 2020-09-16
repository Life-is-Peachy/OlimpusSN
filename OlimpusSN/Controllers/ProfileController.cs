using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;
using System.Threading.Tasks;

namespace OlimpusSN.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IPersonRepository _repository;
        private IPersonCommonRepository _crepository;
        private IPersonHobbiesRepository _hrepository;
        private SignInManager<AppUser> signInManager;

        public ProfileController(SignInManager<AppUser> sgnMgr, IPersonRepository repo,
            IPersonCommonRepository crepo, IPersonHobbiesRepository hrepo)
        {
            signInManager = sgnMgr;
            _repository = repo;
            _crepository = crepo;
            _hrepository = hrepo;
        }

        public IActionResult ProfileAbout() => View();

        public IActionResult ProfilePage() => View();

        public IActionResult Newsfeed() => View();

        public IActionResult PersonCommon()
        {
            string userId = signInManager.UserManager.GetUserId(User);
            ViewBag.FirstName = _repository.GetUser(userId).UserName;
            ViewBag.LastName = _repository.GetUser(userId).LastName;
            ViewBag.Email = _repository.GetUser(userId).Email;
            ViewBag.Birthday = _repository.GetUser(userId).Birthday;
            ViewBag.Gender = _repository.GetUser(userId).Gender;
            return View(_crepository.GetPerson(userId));
        }

        public IActionResult PersonHobbies()
        {
            string userId = signInManager.UserManager.GetUserId(User);
            return View(_hrepository.GetPerson(userId));
        }

        


        [HttpPost]
        public IActionResult CommonSave(PersonCommon common)
        {
            _crepository.Update(common);
            return View(nameof(PersonCommon));
        }


        [HttpPost]
        public IActionResult HobbiesSave(PersonHobbies interests)
        {
            _hrepository.Update(interests);
            return View(nameof(PersonHobbies));
        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(ProfilePage));
        }
    }
}
