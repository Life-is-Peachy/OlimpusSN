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
        private SignInManager<AppUser> signInManager;
        private ICommonInfoRepository _repository;

        public ProfileController(SignInManager<AppUser> sgnMgr, ICommonInfoRepository repo)
        {
            signInManager = sgnMgr;
            _repository = repo;
        }

        public IActionResult ProfileAbout() => View();

        public IActionResult ProfilePage() => View();

        public IActionResult PersonalInformation() => View(_repository.Records.First());

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(ProfilePage));
        }

        public IActionResult SaveInformation(CommonInfo info)
        {
            _repository.SaveInfo(info);
            return RedirectToAction(nameof(PersonalInformation));
        }
    }
}
