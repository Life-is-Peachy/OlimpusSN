using Microsoft.AspNetCore.Mvc;

namespace OlimpusSN.Components
{
    public class BlogPostComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
