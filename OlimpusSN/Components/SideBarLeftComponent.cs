using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class SideBarLeftComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
