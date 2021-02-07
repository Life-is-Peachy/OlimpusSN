using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;
using System.Linq;

namespace OlimpusSN.Components
{
    public class LastPhotosComponent : ViewComponent
    {
        private IPhotoRepository _repository;

        public LastPhotosComponent(IPhotoRepository repo) => _repository = repo;

        public IViewComponentResult Invoke()
        {
            var Photos = _repository.GetPhotografy(this.GetId()).Take(12);

            return View(Photos);
        }
    }
}
