using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class TwitterComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
