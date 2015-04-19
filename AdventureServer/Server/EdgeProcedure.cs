using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server.Database
{
    class EdgeProcedure
    {
        private IDatabase database;
        private string getEdgeCommandText;

        public EdgeProcedure(IDatabase database)
        {
            this.database = database;
            this.getEdgeCommandText = "dbo.GetEdge";
        }

        public Tuple<int, string> GetEdge(int edgeID)
        {
            SqlCommand command = this.database.Connection.CreateCommand();
            command.CommandText = this.getEdgeCommandText;
            command.Connection = this.database.Connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EdgeID", edgeID));
            this.database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            Tuple<int, string> returnTuple = null;
            if (reader.Read())
            {
                int rid = (int)reader["EdgeID"];
                string type = (string)reader["Type"];
                returnTuple = new Tuple<int, string>(rid, type);
            }
            this.database.CloseConnection();
            return returnTuple;
        }
    }
}
