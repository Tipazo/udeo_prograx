using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UDEOExceptionless.DB
{
    public class ClientesDb
    {
        private readonly Connection conn;

        ClientesDb()
        {
            conn = new Connection();
        }

        public List<string> getAll()
        {
            conn.connection.Open();
            string query = " Select * from Cliente";
            conn.sqlCommand = new SqlCommand(query, conn.connection);
            conn.sqlDataReader = conn.sqlCommand.ExecuteReader();

            List<string> c = new List<string>();

            if (conn.sqlDataReader.HasRows)
            {
                while (conn.sqlDataReader.Read())
                {
                    c.Add(conn.sqlDataReader[0].ToString());
                }
            }

            return c;
        }

    }
}