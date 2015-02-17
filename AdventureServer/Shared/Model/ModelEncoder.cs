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
        public class ModelEncoder : IModelEncoder
        {
            private IDatabase database;

            public ModelEncoder(IDatabase database)
            {
                this.database = database;
            }

            public void AddRegion(IRegion region)
            {
                this.database.Access.Region.AddRegion(region);
            }

            public void ClearDatabase()
            {
                this.database.Access.ClearDatabase();
            }
        }
    }
}
