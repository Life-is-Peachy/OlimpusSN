using System.Collections.Generic;
using System.Linq;

namespace OlimpusSN.Models
{
    public interface IPhotoRepository
    {
        User GetUser(long id);
        long AddPhoto(Photografy photo);
        IEnumerable<Photografy> GetPhotografy(long id);
        void DeletePhoto(long id);
        void SetHeader(long userID, long photoID);
        void SetProfile(long userID, long photoID);
    }

    public class PhotoRepository : IPhotoRepository
    {
        private readonly OlympusDbContext _context;

        public PhotoRepository(OlympusDbContext ctx) 
            => _context = ctx;


        public long AddPhoto(Photografy photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();

            return photo.Id;
        }

        public void SetHeader(long userID, long photoID)
        {
            _context.Users.First(x => x.Id == userID).HeaderPhotoId = photoID;
            _context.SaveChanges();
        }

        public void SetProfile(long userID, long photoID)
        {
            _context.Users.First(x => x.Id == userID).ProfilePhotoId = photoID;
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

