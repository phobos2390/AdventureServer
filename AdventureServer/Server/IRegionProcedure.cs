using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    namespace Database
    {
        interface IRegionProcedure
        {
            Tuple<int, string> GetRegionBasicInfo(int regionID);
            IList<Tuple<int, int, string>> GetAllLocationsForRegion(int regionID);
            void AddRegionBasicInfo(Tuple<int, string> basicInfo);
        }
    }
}
