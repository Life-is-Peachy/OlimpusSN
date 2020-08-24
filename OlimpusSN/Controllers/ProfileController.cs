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
        private SignInManager<AppUser> signInManager;

        public ProfileController(SignInManager<AppUser> sgnMgr) => signInManager = sgnMgr;

        public IActionResult ProfileAbout() => View();

        public IActionResult ProfilePage() => View();

        public IActionResult AccountPersonalInformation() => View();

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(ProfilePage));
        }
    }
}
