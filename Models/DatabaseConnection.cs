using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TodoApi.Models
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;
        private MySqlConnection _connection;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }

        public void Disconnect()
        {
            _connection.Close();
        }

        public string ExecuteSql(string sql)
        {
            var cd="";
            var command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            // MySqlDataReader rdr = command.ExecuteReader();
            // while (rdr.Read())
            // {
            //      cd = Convert.ToString(rdr["FirstName"]);
            //      Console.WriteLine(cd);
            //      Console.WriteLine(rdr["LastName"]);
                 
            // }
            return cd;
            
        }

    }
}