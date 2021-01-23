using System.Collections.Generic;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPhotoRepository
    {
        User GetUser(long id);
        void AddPhoto(Photografy photo);
        IEnumerable<Photografy> GetPhotografy(long id);
        void DeletePhoto(long id);
    }

    public class PhotoRepository : IPhotoRepository
    {
        private OlympusDbContext _context;

        public PhotoRepository(OlympusDbContext ctx) 
            => _context = ctx;


        public void AddPhoto(Photografy photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public void DeletePhoto(long id)
        {
            _context.Photos.Remove(_context.Photos.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }


        public IEnumerable<Photografy> GetPhotografy(long id)
            => _context.Photos.Where(x => x.User.Id == id);


        public User GetUser(long id)
            => _context.Users.FirstOrDefault(x => x.Id == id);
    }
}

