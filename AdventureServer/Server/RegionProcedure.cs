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
        class RegionProcedure : IRegionProcedure
        {
            private IDatabase database;
            private string regionBasicInfoCommandText;
            private string allRegionLocationsCommandText;
            private string addRegionCommandText;

            public RegionProcedure(IDatabase database)
            {
                this.regionBasicInfoCommandText = "dbo.GetRegionInfo";
                this.allRegionLocationsCommandText = "dbo.GetAllRegionLocationsAndAdjacencies";
                this.addRegionCommandText = "dbo.AddRegion";
                this.database = database;
            }
            
            public Tuple<int, string> GetRegionBasicInfo(int regionID)
            {
                SqlCommand command = this.database.Connection.CreateCommand();
                command.CommandText = this.regionBasicInfoCommandText;
                command.Connection = this.database.Connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@RegionID", regionID));
                this.database.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();
                Tuple<int, string> returnTuple = null;
                if (reader.Read())
                {
                    int id = (int)reader["RegionID"];
                    string name = (string)reader["Name"];
                    returnTuple = new Tuple<int, string>(id, name);
                }
                this.database.CloseConnection();
                return returnTuple;
            }

            public IList<Tuple<int, int, string>> GetAllLocationsForRegion(int regionID)
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = this.allRegionLocationsCommandText;
                command.Connection = this.database.Connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@RegionID", regionID));
                this.database.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();
                IList<Tuple<int, int, string>> returnTable = new List<Tuple<int, int, string>>();
                if (reader.Read())
                {
                    do
                    {
                        int RID = (int)reader["RegionID"];
                        int LID = (int)reader["LocationID"];
                        string name = (string)reader["Name"];
                        returnTable.Add(new Tuple<int, int, string>(RID, LID, name));
                    }
                    while (reader.Read());
                }
                this.database.CloseConnection();
                return returnTable;
            }

            public void AddRegionBasicInfo(Tuple<int, string> basicInfo)
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = this.addRegionCommandText;
                command.Connection = this.database.Connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@RegionID", basicInfo.Item1));
                command.Parameters.Add(new SqlParameter("@Name", basicInfo.Item2));
                this.database.OpenConnection();
                command.ExecuteNonQuery();
                this.database.CloseConnection();
            }
        }
    }
}
