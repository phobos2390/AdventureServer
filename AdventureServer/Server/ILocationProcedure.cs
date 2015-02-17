using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    namespace Database
    {
        public interface ILocationProcedure
        {
            Tuple<int, int, string> GetLocation(int locationID);
            IList<int> GetAdjacencies(int locationID);
            void AddLocation(Tuple<int, int, string> locationValues);
            void SetAdjacent(Tuple<int, int> adjacencyValues);
        }
    }
}
