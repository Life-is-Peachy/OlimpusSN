using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class TopHeaderProfile : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}