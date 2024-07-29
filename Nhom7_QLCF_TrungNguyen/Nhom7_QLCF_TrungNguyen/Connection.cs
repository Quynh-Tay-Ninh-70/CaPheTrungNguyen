using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Giaodiendangnhap
{
    class Connection
    {
        private static string stringconnection = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLCOFFEE_TRUNGNGUYEN;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringconnection);
        }
    }
}
