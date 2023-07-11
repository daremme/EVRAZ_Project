using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRAZ_Project
{
    public class DB_Con
    {
        SqlConnection connection = new SqlConnection(@"Data Source = KOMPIK\SQLEXPRESS01; Initial Catalog = EvrazDB_Test; Integrated Security = true");

        public void Open()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void Close()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public SqlConnection GetConn()
        {
            return connection;
        }
    }
}
