using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Database;

namespace Shared
{
    namespace Model
    {
        public class ModelLoader : IModelLoader
        {
            private IDatabase database;

            public ModelLoader(IDatabase database)
            {
                this.database = database;
            }

            public IRegion GetRegion(int regionID)
            {
                return this.database.Access.Region.GetRegion(regionID);
            }
        }
    }
}
