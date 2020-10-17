using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;
using System;
using System.Threading.Tasks;

namespace OlimpusSN.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public long UserId => Convert.ToInt64(signInManager.UserManager.GetUserId(User));

        private readonly SignInManager<AppUser> signInManager;

        private readonly IPersonRepository<PersonHobbies> _hobbiesRepository;

        private readonly IPersonRepository<PersonCommon> _commonRepository;

        private readonly IPersonRepository<PersonEducation> _educationRepository;

        private readonly IPersonRepository<PersonEmployement> _employementRepository;

        private readonly IPersonRepository<PersonAll> _allRepository;


        public ProfileController(SignInManager<AppUser> sgnMgr, IPersonRepository<PersonHobbies> hobbie, IPersonRepository<PersonCommon> common,
            IPersonRepository<PersonEducation> education, IPersonRepository<PersonEmployement> employement, IPersonRepository<PersonAll> all)
        {
            signInManager = sgnMgr;
            _hobbiesRepository = hobbie;
            _commonRepository = common;
            _educationRepository = education;
            _employementRepository = employement;
            _allRepository = all;
        }


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
            return View(_allRepository.GetPersonAll(UserId));
        }


        public IActionResult PersonEducation()
        {
            return View(_educationRepository.GetPerson(UserId));
        }


        public IActionResult PersonEmployement()
        {
            return View(_employementRepository.GetPerson(UserId));
        }


        public IActionResult PersonHobbies()
        {
            return View(_hobbiesRepository.GetPerson(UserId));
        }


        public IActionResult PersonCommon()
        {
            return View(_commonRepository.GetPerson(UserId));
        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(ProfilePage));
        }


        [HttpPost]
        public RedirectResult EducationSave(PersonEducation education, string returnUrl)
        {
            _educationRepository.Update(education);
            return Redirect(returnUrl);
        }


        [HttpPost]
        public RedirectResult EmployementSave(PersonEmployement employement, string returnUrl)
        {
            _employementRepository.Update(employement);
            return Redirect(returnUrl);
        }


        [HttpPost]
        public RedirectResult CommonSave(PersonCommon common, string returnUrl)
        {
            _commonRepository.Update(common);
            return Redirect(returnUrl);
        }


        [HttpPost]
        public RedirectResult HobbiesSave(PersonHobbies interests, string returnUrl)
        {
            _hobbiesRepository.Update(interests);
            return Redirect(returnUrl);
        }
    }
}
