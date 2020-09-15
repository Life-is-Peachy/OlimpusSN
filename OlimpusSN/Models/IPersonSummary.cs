using System.Collections.Generic;

namespace OlimpusSN.Models
{
    public interface IPersonSummary
    {
        public IEnumerable<InfoCommon> PersonSummaryRecords { get; }

        void SaveCommonInfo(InfoCommon info);

        void SaveHobbiesInfo(AppUser info);

        void SaveEducationInfo(AppUser info);

        void SaveEmployementInfo(AppUser info);
    }
}
