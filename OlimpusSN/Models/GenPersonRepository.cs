using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpusSN.Models
{
    public class GenPersonRepository<T> where T : class
    {
        protected AppIdentityDbContext _context;

        GenPersonRepository(AppIdentityDbContext ctx) => _context = ctx;

        public virtual T GetPerson(string id)
        {
            var s = _context.Set<T>().Find(id);
            return s;
        }
    }
}
