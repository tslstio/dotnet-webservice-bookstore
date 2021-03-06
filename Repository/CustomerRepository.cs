using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using WebServiceBookStore.Models;

namespace WebServiceBookStore.Repository
{
    public class CustomerRepository
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=toko_buku;Uid=root");

        public System.Collections.Generic.List<Customer> GetAll()
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM customer").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetById(int id)
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM customer WHERE Id_Customer = @id", new { id }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetByEmail(string email)
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM customer WHERE Email = @email", new { email }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Insert(Customer Customer)
        {
            string query = "INSERT INTO customer VALUES(null, '" + Customer.Email + "', '" + Customer.Name + "', '" + Customer.Phone +  "', '" + Customer.Address + "')";
            connection.Execute(query);
        }

        public bool Update(Customer Customer)
        {
            string query = "UPDATE customer SET Email = '" + Customer.Email + "', Name = '" + Customer.Name + "', Phone = '" + Customer.Phone + "', Address = '" + Customer.Address + "' WHERE Id_Customer = " + Customer.Id_Customer;
            
            if (connection.Execute(query) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM customer WHERE Id_Customer = @id";
            
            if (connection.Execute(query, new { id }) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
