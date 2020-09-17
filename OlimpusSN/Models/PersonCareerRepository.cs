using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPersonCareerRepository
    {
        PersonCareer GetPerson(string id);

        void Update(PersonCareer career);
    }


    public class PersonCareerRepository : IPersonCareerRepository
    {

        private AppIdentityDbContext _context;


        public PersonCareerRepository(AppIdentityDbContext ctx) => _context = ctx;


        public void Update(PersonCareer career)
        {
            _context.Update(career);
            _context.SaveChanges();
        }


        public PersonCareer GetPerson(string id)
        {
            return _context.UserAll.Include(e => e.PersonAll)
                    .ThenInclude(i => i.PersonCareer).ThenInclude(u => u.PersonEducation)
                    .Include(l => l.PersonAll)
                    .ThenInclude(k => k.PersonCareer).ThenInclude(m => m.PersonEmployement)
                    .First(p => p.Id == id).PersonAll.PersonCareer;
        }
    }
}
