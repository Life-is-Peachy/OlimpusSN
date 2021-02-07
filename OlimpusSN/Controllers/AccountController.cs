using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OlimpusSN.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager mng)
            => _accountManager = mng;


        public ActionResult SignIn()
            => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                bool IsAlreadyExists = _accountManager.UserExists(user.Email);

                if (!IsAlreadyExists)
                {
                    User newUser = new User
                    {
                        Email = user.Email,
                        Password = user.Password,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Birthday = user.Birthday,
                        Gender = user.Gender,
                        PersonAll = SeedData.SeedOnRegister(user.FirstName, user.LastName, user.Email, user.Birthday, user.Gender)
                    };

                    long id = _accountManager.Register(newUser);
                    await Authenticate(id);

                    return RedirectToAction("Profile", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректный логин или пароль");
                }
            }
            return View(nameof(SignIn), user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(User user)
        {
            if (ModelState.IsValid)
            {
                User IfUserExists = _accountManager.SignAhead(user.Email, user.Password);

                if (IfUserExists != null)
                {
                    await Authenticate(IfUserExists.Id);
                    return RedirectToAction("Profile", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректный логин или пароль");
                }
            }
            return View(user);
        }


        public async Task<ActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(SignIn));
        }


        private async Task Authenticate(long id)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
    }
}

