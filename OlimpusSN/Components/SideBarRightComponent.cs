using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class SideBarRightComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View(); 
    }
}
