using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;

namespace OlimpusSN.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IPersonRepository<PersonHobbies> _hobbiesRepository;
        private readonly IPersonRepository<PersonCommon> _commonRepository;
        private readonly IPersonRepository<PersonEducation> _educationRepository;
        private readonly IPersonRepository<PersonEmployement> _employementRepository;
        private readonly IPersonRepository<PersonAll> _allRepository;
        private readonly IPostRepository _postRepository;

        public ProfileController(IPersonRepository<PersonHobbies> hobbie, IPersonRepository<PersonCommon> common, IPersonRepository<PersonEducation> education, IPersonRepository<PersonEmployement> employement, IPersonRepository<PersonAll> all, IPostRepository post)
            => (_hobbiesRepository, _commonRepository, _educationRepository, _employementRepository, _allRepository, _postRepository) = (hobbie, common, education, employement, all, post);


        public IActionResult Profile()
            => View(_postRepository.GetPost(this.GetId()));


        public IActionResult About()
            => View(_allRepository.GetPersonAll(this.GetId()));


        public IActionResult Education()
            => View(_educationRepository.GetPerson(this.GetId()));


        public IActionResult Employement()
            => View(_employementRepository.GetPerson(this.GetId()));


        public IActionResult Hobbies()
            => View(_hobbiesRepository.GetPerson(this.GetId()));


        public IActionResult Common()
            => View(_commonRepository.GetPerson(this.GetId()));


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
