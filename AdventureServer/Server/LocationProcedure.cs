using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server
{
    namespace Database
    {
        class LocationProcedure : ILocationProcedure
        {
            private IDatabase database;
            private string getLocationCommandText;
            private string getAdjacenciesCommandText;
            private string addLocationCommandText;
            private string setAdjacentCommandText;

            public LocationProcedure(IDatabase database)
            {
                this.database = database;
                this.getAdjacenciesCommandText = "dbo.GetAdjacentLocations";
                this.getLocationCommandText = "dbo.GetLocation";
                this.addLocationCommandText = "dbo.AddLocation";
                this.setAdjacentCommandText = "dbo.SetAdjacent";
            }

            public Tuple<int, int, string> GetLocation(int locationID)
            {
                SqlCommand command = this.database.Connection.CreateCommand();
                command.CommandText = this.getLocationCommandText;
                command.Connection = this.database.Connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@LocationID", locationID));
                this.database.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();
                Tuple<int, int, string> returnTuple = null;
                if (reader.Read())
                {
                    int rid = (int)reader["RegionID"];
                    int lid = (int)reader["LocationID"];
                    string name = (string)reader["Name"];
                    returnTuple = new Tuple<int, int, string>(rid, lid, name);
                }
                this.database.CloseConnection();
                return returnTuple;
            }

            public IList<int> GetAdjacencies(int locationID)
            {
                SqlCommand command = this.database.Connection.CreateCommand();
                command.CommandText = this.getAdjacenciesCommandText;
                command.Connection = this.database.Connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@LocationID", locationID));
                this.database.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();
                IList<int> returnList = new List<int>();
                if (reader.Read())
                {
                    do
                    {
                        int lid = (int)reader["DestinationID"];
                        returnList.Add(lid);
                    }
                    while (reader.Read());
                }
                this.database.CloseConnection();
                return returnList;
            }

            public void AddLocation(Tuple<int, int, string> locationValues)
            {
                SqlCommand command = this.database.Connection.CreateCommand();
                command.CommandText = this.addLocationCommandText;
                command.Connection = this.database.Connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@RegionID", locationValues.Item1));
                command.Parameters.Add(new SqlParameter("@LocationID", locationValues.Item2));
                command.Parameters.Add(new SqlParameter("@Name", locationValues.Item3));
                this.database.OpenConnection();
                command.ExecuteNonQuery();
                this.database.CloseConnection();
            }

            public void SetAdjacent(Tuple<int, int> adjacencyValues)
            {
                SqlCommand command = this.database.Connection.CreateCommand();
                command.CommandText = this.setAdjacentCommandText;
                command.Connection = this.database.Connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SourceID", adjacencyValues.Item1));
                command.Parameters.Add(new SqlParameter("@DestinationID", adjacencyValues.Item2));
                this.database.OpenConnection();
                command.ExecuteNonQuery();
                this.database.CloseConnection();
            }
        }
    }
}
