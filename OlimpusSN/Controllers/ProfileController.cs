using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpusSN.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public long UserId => GetId(HttpContext.User.Identity.Name);
        private OlympusDbContext _context;
        private readonly IPersonRepository<PersonHobbies> _hobbiesRepository;
        private readonly IPersonRepository<PersonCommon> _commonRepository;
        private readonly IPersonRepository<PersonEducation> _educationRepository;
        private readonly IPersonRepository<PersonEmployement> _employementRepository;
        private readonly IPersonRepository<PersonAll> _allRepository;
        private readonly IPostRepository _postRepository;


        public ProfileController(IPersonRepository<PersonHobbies> hobbie, IPersonRepository<PersonCommon> common,
            IPersonRepository<PersonEducation> education, IPersonRepository<PersonEmployement> employement, IPersonRepository<PersonAll> all, OlympusDbContext ctx, IPostRepository post)
        {
            _hobbiesRepository = hobbie;
            _commonRepository = common;
            _educationRepository = education;
            _employementRepository = employement;
            _allRepository = all;
            _context = ctx;
            _postRepository = post;
        }


        public IActionResult Profile()
        {
            return View(_postRepository.GetPost(UserId));
        }


        public IActionResult Newsfeed()
        {
            return View();
        }


        public IActionResult About()
        {
            return View(_allRepository.GetPersonAll(UserId));
        }


        public IActionResult Education()
        {
            return View(_educationRepository.GetPerson(UserId));
        }


        public IActionResult Employement()
        {
            return View(_employementRepository.GetPerson(UserId));
        }


        public IActionResult Hobbies()
        {
            return View(_hobbiesRepository.GetPerson(UserId));
        }


        public IActionResult Common()
        {
            return View(_commonRepository.GetPerson(UserId));
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


        private long GetId(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email).ID;
        }
    }
}
