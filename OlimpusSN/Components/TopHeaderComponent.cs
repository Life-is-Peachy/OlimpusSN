using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class TopHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
