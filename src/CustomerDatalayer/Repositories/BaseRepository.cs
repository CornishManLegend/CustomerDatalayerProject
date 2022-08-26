using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Repositories
{
    public class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=.\\SQLEXPRESS;Database=CustomerDB_Kalenishin;Trusted_Connection=True;");
        }
    }
}
