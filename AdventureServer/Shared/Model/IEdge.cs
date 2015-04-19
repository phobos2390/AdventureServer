using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        interface IEdge
        {
            int ID { get; }
            bool CanPass(IPlayer givenPlayer);
        }
    }
}
