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
        private readonly IPersonRepository _repository;

        private readonly IPersonCommonRepository _crepository;

        private readonly IPersonHobbiesRepository _hrepository;

        private readonly IPersonCareerRepository _crrepository;

        private readonly SignInManager<AppUser> signInManager;


        public ProfileController(SignInManager<AppUser> sgnMgr, IPersonRepository repo, IPersonCommonRepository crepo, IPersonHobbiesRepository hrepo, IPersonCareerRepository crrepo)
        {
            signInManager = sgnMgr;
            _repository = repo;
            _crepository = crepo;
            _hrepository = hrepo;
            _crrepository = crrepo;
        }


        public string UserId => signInManager.UserManager.GetUserId(User);


        public IActionResult ProfilePage()
        {
            return View();
        }

        public IActionResult Newsfeed()
        {
            return View();
        }


        public IActionResult ProfileAbout()
        {
            return View(_repository.GetUser(UserId).PersonAll);
        }


        public IActionResult PersonCareer()
        {
            return View(_crrepository.GetPerson(UserId));
        }


        public IActionResult PersonHobbies()
        {
            return View(_hrepository.GetPerson(UserId));
        }


        public IActionResult PersonCommon()
        {
            ViewBag.FirstName = _repository.GetUser(UserId).UserName;
            ViewBag.LastName = _repository.GetUser(UserId).LastName;
            ViewBag.Email = _repository.GetUser(UserId).Email;
            ViewBag.Birthday = _repository.GetUser(UserId).Birthday;
            ViewBag.Gender = _repository.GetUser(UserId).Gender;
            return View(_crepository.GetPerson(UserId));
        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(ProfilePage));
        }


        [HttpPost]
        public RedirectResult CareerSave(PersonCareer career, string returnUrl)
        {
            _crrepository.Update(career);
            return Redirect(returnUrl);
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
    }
}
