using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_helpers
{
    public interface IDBConnection
    {
        bool CheckConnection();
    }
}
