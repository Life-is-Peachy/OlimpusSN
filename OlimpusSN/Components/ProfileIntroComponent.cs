using Microsoft.AspNetCore.Mvc;
using OlimpusSN.Models;

namespace OlimpusSN.Components
{
    public class ProfileIntroComponent : ViewComponent
    {
        private readonly IPersonRepository<PersonCommon> _repository;

        public ProfileIntroComponent(IPersonRepository<PersonCommon> repo) => _repository = repo;

        public IViewComponentResult Invoke()
        {
            var person = _repository.GetPerson(this.GetId());

            return View(person);
        }
    }
}
