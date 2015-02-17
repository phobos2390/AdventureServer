using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        public interface IModelMain
        {
            ILocation CurrentLocation { get; set; }
            IList<ILocation> AdjacentLocations { get; }
            IModelBuilderFactory BuilderFactory { get; }
            IModelLoader Loader { get; }
            IModelEncoder Encoder { get; }
        }
    }
}
