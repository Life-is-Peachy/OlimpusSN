using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class PlaylistComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
