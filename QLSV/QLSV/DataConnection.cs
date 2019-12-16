using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source =DESKTOP-0Q13ULP\\SQLEXPRESS; Initial Catalog=QLSV; Integrated Security=true ";
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
