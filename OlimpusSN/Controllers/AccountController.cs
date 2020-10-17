using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;
using System.Threading.Tasks;

namespace OlimpusSN.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> usrMgr, SignInManager<AppUser> sgnMgr)
        {
            userManager = usrMgr;
            signInManager = sgnMgr;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = SeedData.GenName(),
                    Email = model.Email,
                    PersonAll = SeedData.SeedOnRegister()
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return RedirectToAction("PersonHobbies", "Profile");
                else
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(user, details.Password, false, false);
                    if (result.Succeeded)
                        return Redirect(returnUrl ?? "/");
                }
                else
                    ModelState.AddModelError(nameof(SignInModel.Email), "Invalid User or Password");
            }
            return View(details);
        }
    }
}
