using System.Linq;

namespace OlimpusSN.Models
{
    public class Utils
    {
        private OlympusDbContext _context;

        public Utils(OlympusDbContext ctx)
        {
            _context = ctx;
        }

        public long GetID(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email).ID;
        }
    }
}
