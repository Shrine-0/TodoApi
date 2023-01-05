using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ApexRestaurant.Repository.Domain;
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

        public List<ApexRestaurant.Repository.Domain.Customer> ExecuteSql<Customer>(string sql)
        {

            var cd = "";
            var command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
            MySqlDataReader rdr = command.ExecuteReader();
            List<ApexRestaurant.Repository.Domain.Customer> customers = new List<ApexRestaurant.Repository.Domain.Customer>();//new list to store the results from the query
            
            while (rdr.Read())
            {
                ApexRestaurant.Repository.Domain.Customer read = Activator.CreateInstance<ApexRestaurant.Repository.Domain.Customer>();

                cd = Convert.ToString(rdr["FirstName"]);
                Console.WriteLine(cd);
                Console.WriteLine(rdr["LastName"]);
                read.Id =Convert.ToInt32(rdr["Customer_Id"]);
                read.FirstName = rdr["FirstName"].ToString();
                read.LastName = rdr["LastName"].ToString();
                read.Address = rdr["Address"].ToString();
                read.PhoneRes = rdr["PhoneRes"].ToString();
                read.PhoneMob = rdr["PhoneMob"].ToString();
                //read.EnrollDate = rdr["EnrollDate"].ToString();

                customers.Add(read);
            }
            //rdr.Close();
        
         return customers;

            
        }

}
}