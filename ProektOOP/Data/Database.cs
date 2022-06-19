using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProektOOP.Data
{
    static class Database
    {
        public static SqlConnection Connect()
        {
            string conText = "Server= DESKTOP-7RDK6T8;Database = Market;Integrated Security = true";
            SqlConnection con = new SqlConnection(conText);
            return con;
        }
    }
}
