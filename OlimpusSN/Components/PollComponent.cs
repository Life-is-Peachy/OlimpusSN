using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class PollComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
