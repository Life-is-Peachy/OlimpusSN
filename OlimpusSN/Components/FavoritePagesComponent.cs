using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class FavoritePagesComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
