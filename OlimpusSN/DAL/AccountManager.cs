using System.Linq;

namespace OlimpusSN.Models
{
    public interface IAccountManager
    {
        public bool UserExists(string email);
        public long Register(User user);
        public User SignAhead(string email, string password);
    }

    public class AccountManager : IAccountManager
    {
        private readonly OlympusDbContext _context;

        public AccountManager(OlympusDbContext ctx)
            => _context = ctx;


        public long Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public bool UserExists(string email)
            => _context.Users.FirstOrDefault(x => x.Email == email) != null;


        public User SignAhead(string email, string password)
            => _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
    }
}
