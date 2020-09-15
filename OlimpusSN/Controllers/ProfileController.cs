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
        private IPersonSummary _repository;
        private SignInManager<AppUser> signInManager;

        public ProfileController(SignInManager<AppUser> sgnMgr, IPersonSummary repo)
        {
            signInManager = sgnMgr;
            _repository = repo;
        }

        public IActionResult ProfileAbout() => View();

        public IActionResult ProfilePage() => View();

        public IActionResult Newsfeed() => View();

        public IActionResult PersonalInformation()
        {
            return View(_repository.PersonSummaryRecords.First());
        }

        public IActionResult SaveCommonInfo(InfoCommon info)
        {
            _repository.SaveCommonInfo(info);
            return RedirectToAction(nameof(PersonalInformation));
        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(ProfilePage));
        }
    }
}
