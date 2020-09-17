using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPersonHobbiesRepository
    {
        void Update(PersonHobbies hobbies);

        PersonHobbies GetPerson(string id);
    }


    public class PersonHobbiesRepository : IPersonHobbiesRepository
    {

        private AppIdentityDbContext _context;


        public PersonHobbiesRepository(AppIdentityDbContext ctx) => _context = ctx;


        public void Update(PersonHobbies hobbies)
        {
            _context.Update(hobbies);
            _context.SaveChanges();
        }


        public PersonHobbies GetPerson(string id)
        {
            return _context.UserAll.Include(i => i.PersonAll)
                .ThenInclude(e => e.PersonHobbies)
                .First(p => p.Id == id).PersonAll.PersonHobbies;
        }
    }
}
