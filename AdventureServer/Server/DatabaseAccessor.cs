using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Shared.Model;

namespace Server
{
    namespace Database
    {
        public class DatabaseAccessor : IDatabaseAccessor
        {
            private IDatabase database;
            private IRegionAccessor region;
            private ILocationAccessor location;

            private string clearDatabaseCommandText;

            public DatabaseAccessor(IDatabase database, IModelMain model)
            {
                this.database = database;
                this.clearDatabaseCommandText = "dbo.ClearDatabase";
                this.region = new RegionAccessor(database, model);
                this.location = new LocationAccessor(database, model);
            }

            public IRegionAccessor Region
            {
                get { return this.region; }
            }

            public ILocationAccessor Location
            {
                get { return this.location; }
            }

            public void ClearDatabase()
            {
                SqlCommand command = this.database.Connection.CreateCommand();
                command.CommandText = this.clearDatabaseCommandText;
                command.Connection = this.database.Connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                this.database.OpenConnection();
                command.ExecuteNonQuery();
                this.database.CloseConnection();
            }
        }
    }
}
