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
        public interface IDatabase
        {
            IDatabaseAccessor Access { get; }
            SqlConnection Connection { get; }
            void OpenConnection();
            void CloseConnection();
        }
    }
}
