using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlimpusSN.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OlimpusSN.Controllers
{
    public class AccountController : Controller
    {
        private OlympusDbContext _context;

        public AccountController(OlympusDbContext ctx) => _context = ctx;



        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                User IsUserAlreadyExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

                if (IsUserAlreadyExists == null)
                {
                    _context.Users.Add(new User
                    {
                        Email = user.Email,
                        Password = user.Password,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Birthday = user.Birthday,
                        Gender = user.Gender,
                        PersonAll = SeedData.SeedOnRegister(user.FirstName, user.LastName, user.Email, user.Birthday, user.Gender)
                });
                    await _context.SaveChangesAsync();
                    await Authenticate(user.Email);

                    return RedirectToAction("Profile", "Profile");
                }
                else
                    ModelState.AddModelError("", "Некорректный логин или пароль");
            }
            return View(nameof(SignIn), user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(User user)
        {
            if (ModelState.IsValid)
            {
                User IsUserExists = await _context.Users.
                    FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);

                if (IsUserExists != null)
                {
                    await Authenticate(user.Email);
                    return RedirectToAction("Profile", "Profile");
                }
                else
                    ModelState.AddModelError("", "Некорректный логин или пароль");
            }
            return View(user);
        }


        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(SignIn));
        }


        private async Task Authenticate(string Email)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, Email)
            };

            ClaimsIdentity identity = new ClaimsIdentity
                (claims,
                "OlympusCoockie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync
                (CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}
