using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Components.ComponentsModels;
using OlimpusSN.Models;
using System.Linq;

namespace OlimpusSN.Components
{
    public class TopHeaderProfile : ViewComponent
    {
        private readonly OlympusDbContext _context;

        public TopHeaderProfile(OlympusDbContext ctx)
            => _context = ctx;


        public IViewComponentResult Invoke()
        {
            long thumbID = _context.Users.FirstOrDefault(x => x.Id == this.GetId()).HeaderPhotoId;
            long avatarID = _context.Users.FirstOrDefault(x => x.Id == this.GetId()).ProfilePhotoId;

            Header model = new Header
            {
                Thumb = _context.Photos.FirstOrDefault(x => x.Id == thumbID).Name,
                Avatar = _context.Photos.FirstOrDefault(x => x.Id == avatarID).Name
            };

            return View(model);
        }
    }
}