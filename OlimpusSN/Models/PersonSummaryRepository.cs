using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OlimpusSN.Models
{
    public class PersonSummaryRepository : IPersonSummary
    {
        private AppIdentityDbContext context;
        private UserDbContext _context;

        public PersonSummaryRepository(UserDbContext ctx, AppIdentityDbContext ictx)
        {
            _context = ctx;
            context = ictx;
        }

        public IEnumerable<InfoCommon> PersonSummaryRecords => _context.InfoCommon;

        public void SaveCommonInfo(InfoCommon info)
        {
            
            _context.SaveChanges();
        }

        public void SaveEducationInfo(AppUser info)
        {
            var Education = info.PersonSummary.InfoEducation;
            _context.InfoEducation.Add(Education);
            _context.SaveChanges();
        }

        public void SaveEmployementInfo(AppUser info)
        {
            var Employement = info.PersonSummary.InfoEmployement;
            _context.InfoEmployement.Add(Employement);
            _context.SaveChanges();
        }

        public void SaveHobbiesInfo(AppUser info)
        {
            var Hobbies = info.PersonSummary.InfoHobbies;
            _context.InfoHobbies.Add(Hobbies);
            _context.SaveChanges();
        }
    }
}
