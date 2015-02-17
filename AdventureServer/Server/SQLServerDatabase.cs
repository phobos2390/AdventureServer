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
        class SQLServerDatabase : IDatabase
        {
            private string connectionString;
            
            private IDatabaseAccessor accessor;
            private SqlConnection connection;

            public SQLServerDatabase(IModelMain model)
            {
                connectionString = "Data Source=JAMES-PC\\SQLEXPRESS;" +
                                    "Initial Catalog=AdventureDatabase;" +
                                    "Integrated Security=True;" +
                                    "Connect Timeout=15;" +
                                    "Encrypt=False;" +
                                    "TrustServerCertificate=False";
                this.connection = new SqlConnection(connectionString);
                this.accessor = new DatabaseAccessor(this, model);
            }

            public IDatabaseAccessor Access
            {
                get { return accessor; }
            }

            public System.Data.SqlClient.SqlConnection Connection
            {
                get { return connection; }
            }

            public void OpenConnection()
            {
                connection.Open();
            }

            public void CloseConnection()
            {
                connection.Close();
            }
        }
    }
}
