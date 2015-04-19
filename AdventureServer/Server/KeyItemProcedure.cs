using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server.Database
{
    class KeyItemProcedure : IItemSubTypeProcedure
    {
        private IDatabase database;
        private string type;
        private string getKeyItemCommandText;
        private string addKeyItemCommandText;

        public KeyItemProcedure(IDatabase database)
        {
            this.database = database;
            this.type = "Key";
            this.getKeyItemCommandText = "dbo.GetKeyItem";
            this.addKeyItemCommandText = "dbo.AddKeyItem";
        }

        public object GetItemValuesFromID(int id)
        {
            SqlCommand command = this.database.Connection.CreateCommand();
            command.CommandText = this.getKeyItemCommandText;
            command.Connection = this.database.Connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ItemID", id));
            this.database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            Tuple<string,string> returnTuple = null;
            if (reader.Read())
            {
                string name = (string)reader["name"];
                string text = (string)reader["text"];
                returnTuple = Tuple.Create<string, string>(name, text);
            }
            this.database.CloseConnection();
            return returnTuple;
        }

        public bool IsOfSubtype(string type)
        {
            return type == this.type;
        }

        public void AddItem(object itemValues)
        {
            Tuple<int, string, string> tup = (Tuple<int, string, string>)itemValues;
            SqlCommand command = new SqlCommand();
            command.CommandText = this.addKeyItemCommandText;
            command.Connection = this.database.Connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ItemID", tup.Item1));
            command.Parameters.Add(new SqlParameter("@Name", tup.Item2));
            command.Parameters.Add(new SqlParameter("@Text", tup.Item3));
            this.database.OpenConnection();
            command.ExecuteNonQuery();
            this.database.CloseConnection();
        }
    }
}
