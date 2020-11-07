using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPersonRepository<T> where T : class
    {
        T GetPerson(long id);

        void Update(T data);

        PersonAll GetPersonAll(long id);
    }

    public class PersonRepository<T> : IPersonRepository<T> where T : class
    {
        private OlympusDbContext _context;


        public PersonRepository(OlympusDbContext ctx) => _context = ctx;


        public void Update(T data)
        {
            _context.Update<T>(data);
            _context.SaveChanges();
        } 
        

        public T GetPerson(long id)
        {
            return _context.Set<T>().Find(id);
        }


        public PersonAll GetPersonAll(long id)
        { 
            return _context.Users.Include(e => e.PersonAll.PersonCommon)
                .Include(u => u.PersonAll.PersonHobbies)
                .Include(o => o.PersonAll.PersonEducation)
                .Include(a => a.PersonAll.PersonEmployement)
                .First(y => y.ID == id).PersonAll;
        }
    }
}
