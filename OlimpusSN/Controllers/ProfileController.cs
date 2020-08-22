using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult ProfileAbout()
        {
            return View();
        }
        public IActionResult ProfilePage()
        {
            return View();
        }
    }
}
