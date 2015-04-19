using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;
using System.Data.SqlClient;

namespace Server.Database
{
    class KeyEdgeProcedure
    {
        private IDatabase database;
        private string getKeyItemEdgeCommandText;

        public KeyEdgeProcedure(IDatabase database)
        {
            this.database = database;
            this.getKeyItemEdgeCommandText = "dbo.GetKeyItemEdge";
        }

        public Tuple<int, int> GetEdge(int edgeID)
        {
            SqlCommand command = this.database.Connection.CreateCommand();
            command.CommandText = this.getKeyItemEdgeCommandText;
            command.Connection = this.database.Connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EdgeID", edgeID));
            this.database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            Tuple<int, int> returnTuple = null;
            if (reader.Read())
            {
                int rid = (int)reader["EdgeID"];
                int iid = (int)reader["KeyItemID"];
                returnTuple = new Tuple<int, int>(rid, iid);
            }
            this.database.CloseConnection();
            return returnTuple;
        }
    }
}
