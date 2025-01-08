
using BackendDevIntroRazorWebApp8.Models;
using Microsoft.Data.SqlClient;

namespace BackendDevIntroRazorWebApp8.Services
{
    public class CustomersService
    {
        static List<Customer> Customers { get; }
        static CustomersService()
        {
            Customers = new List<Customer>();
        }

        public static List<Customer> GetAll()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                String sql = "SELECT CustomerID, CompanyName FROM Customers";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Customers.Clear();
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.CustomerID = reader.GetString(0);
                            customer.CompanyName = reader.GetString(1);
                            Customers.Add(customer);
                        }
                    }
                }
                return Customers;
            }
        }
    }
}
