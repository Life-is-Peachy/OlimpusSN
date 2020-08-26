using System.Collections.Generic;

namespace OlimpusSN.Models
{
    public interface ICommonInfoRepository
    {
        public IEnumerable<CommonInfo> Records { get; }

        void SaveInfo(CommonInfo info);
    }
}
