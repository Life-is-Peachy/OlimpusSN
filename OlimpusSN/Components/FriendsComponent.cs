using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class FriendsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
