using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpusSN.Models
{
    public class CommonInfoRepository : ICommonInfoRepository
    {
        private UserDbContext _context;

        public CommonInfoRepository(UserDbContext ctx) => _context = ctx;

        public IEnumerable<CommonInfo> Records => _context.InfoCommon;

        public void SaveInfo(CommonInfo info)
        {
            _context.InfoCommon.Add(info);
            _context.SaveChanges();
        }
    }
}
