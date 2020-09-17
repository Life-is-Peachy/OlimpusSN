using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPersonRepository
    {
        AppUser GetUser(string id);
    }


    public class PersonRepository : IPersonRepository
    {

        private AppIdentityDbContext _context;


        public PersonRepository(AppIdentityDbContext ctx) => _context = ctx;


        public AppUser GetUser(string id)
        {
            return _context.UserAll.Include(i => i.PersonAll.PersonHobbies)
            .Include(o => o.PersonAll.PersonCommon)
            .Include(u => u.PersonAll.PersonCareer)
            .ThenInclude(y => y.PersonEducation)
            .Include(a => a.PersonAll.PersonCareer.PersonEmployement)
            .First(e => e.Id == id);
        }
    }
}
