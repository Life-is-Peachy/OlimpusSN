using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class LastVideoComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
