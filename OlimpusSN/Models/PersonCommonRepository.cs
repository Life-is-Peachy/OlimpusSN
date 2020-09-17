using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPersonCommonRepository
    {
        void Update(PersonCommon person);

        PersonCommon GetPerson(string id);
    }


    public class PersonCommonRepository : IPersonCommonRepository
    {

        private AppIdentityDbContext _context;


        public PersonCommonRepository(AppIdentityDbContext ctx) => _context = ctx;


        public void Update(PersonCommon person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }


        public PersonCommon GetPerson(string id)
        {
            return _context.UserAll.Include(i => i.PersonAll)
                .ThenInclude(e => e.PersonCommon)
                .First(p => p.Id == id).PersonAll.PersonCommon;
        }
    }
}
