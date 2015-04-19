using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server.Database
{
    class ItemProcedure
    {
        private IDatabase database;
        private string getItemType;
        private string addItemToInventoryCommandText;

        public ItemProcedure(IDatabase database)
        {
            this.database = database;
            this.getItemType = "dbo.GetItemType";
            this.addItemToInventoryCommandText = "dbo.AddItemToInventory";
        }

        public string GetItemType(int itemID)
        {
            SqlCommand command = this.database.Connection.CreateCommand();
            command.CommandText = this.getItemType;
            command.Connection = this.database.Connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ItemID", itemID));
            this.database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            string type = null;
            if (reader.Read())
            {
                type = (string)reader["ItemType"];
            }
            this.database.CloseConnection();
            return type;
        }

        public void AddItemToInventory(int itemID, int playerID)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = this.addItemToInventoryCommandText;
            command.Connection = this.database.Connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ItemID", itemID));
            command.Parameters.Add(new SqlParameter("@PlayerID", playerID));
            this.database.OpenConnection();
            command.ExecuteNonQuery();
            this.database.CloseConnection();
        }
    }
}
