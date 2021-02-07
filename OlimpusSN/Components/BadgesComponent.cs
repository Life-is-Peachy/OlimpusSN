using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class BadgesComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
