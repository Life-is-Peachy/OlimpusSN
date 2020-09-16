using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public PersonCommonRepository(AppIdentityDbContext ctx)
        {
            _context = ctx;
        }


        public void Update(PersonCommon person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }


        public PersonCommon GetPerson(string id)
        {
            var s = _context.UserAll.Include(i => i.PersonAll)
                .ThenInclude(e => e.PersonCommon).First(p => p.Id == id);
            return s.PersonAll.PersonCommon;

        }
    }
}
