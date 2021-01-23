using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;

namespace OlimpusSN.Controllers
{
    public interface IUploader
    {
        Task<Photografy> Upload(IFormFile file);
    }

    public interface IDeleter
    {
        void Delete(string photoName);
    }


    public class ContentController : Controller
    {
        private class PhotoManager : IUploader, IDeleter
        {
            private static readonly string folder = "/Content/Photografy/";
            private readonly User _user;
            private readonly string _env;

            public PhotoManager(User user, string env)
                => (_user, _env) = (user, env);

            public PhotoManager(string env)
                => _env = env;


            public async Task<Photografy> Upload(IFormFile file)
            {
                using (var fileStream = new FileStream(_env + folder + file.FileName, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                Photografy photo = new Photografy
                {
                    UploadDate = DateTime.Now,
                    Name = folder + file.FileName,
                    User = _user
                };

                return photo;
            }

            public void Delete(string photoName)
                => System.IO.File.Delete(_env + photoName);
        }

        private readonly IWebHostEnvironment _env;
        private readonly IPhotoRepository _repository;

        public ContentController(IWebHostEnvironment env, IPhotoRepository repo)
            => (_repository, _env) = (repo, env);



        public ActionResult Photos()
            => View(_repository.GetPhotografy(this.GetId()));


        [HttpPost]
        public async Task<ActionResult> UploadAsync(IFormCollection photos)
        {
            User user = _repository.GetUser(this.GetId());

            IUploader uploader = new PhotoManager(user, _env.WebRootPath);

            foreach (IFormFile photo in photos.Files)
            {
                Photografy photografy = await uploader.Upload(photo);
                _repository.AddPhoto(photografy);
            }

            return RedirectToAction(nameof(Photos));
        }

        public ActionResult Delete(long id, string name)
        {
            _repository.DeletePhoto(id);

            IDeleter deleter = new PhotoManager(_env.WebRootPath);
            deleter.Delete(name);

            return RedirectToAction(nameof(Photos));
        }
    }
}
