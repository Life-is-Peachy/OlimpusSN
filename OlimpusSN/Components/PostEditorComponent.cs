using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;

namespace OlimpusSN.Components
{
    public class PostEditorComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new Post());
        }
    }
}
