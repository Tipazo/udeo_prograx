using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UDEOExceptionless.DB
{
    public class Connection
    {
        public SqlConnection connection;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlDataReader;

        public Connection()
        {
            // server 
            connection = new SqlConnection("Data Source=DESKTOP-1255AH6\\SQLEXPRESS;Initial Catalog=Udeo;Integrated Security=True");
        }
    }
}