using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpusSN.Models
{
    public interface IPersonRepository
    {
        AppUser GetUser(string id);

        void SavePersonInfo(AppUser person);
    }
    public class PersonRepository : IPersonRepository
    {
        private AppIdentityDbContext _context;

        public PersonRepository(AppIdentityDbContext ctx)
        {
            _context = ctx;
        }


        public AppUser GetUser(string id)
        {
            return _context.UserAll.Include(i => i.PersonAll)
                .ThenInclude(e => e.PersonCommon).First(p => p.Id == id);
        }


        public void SavePersonInfo(AppUser person)
        {
            var s = this.GetUser(person.Id);
            _context.UserAll.Update(s);
            _context.SaveChanges();
        }
    }
}
