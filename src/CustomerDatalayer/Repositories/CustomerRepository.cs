using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public void Create(Customer entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO [Customers] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount)" +
                    " VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount)",
                    connection);

                var customerFirstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                var customerLastNameParam = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = entity.LastName
                };
                var customerPhoneNumberParam = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.NVarChar, 15)
                {
                    Value = entity.PhoneNumber
                };
                var customerEmailParam = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 100)
                {
                    Value = entity.Email
                };
                var customerTotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", System.Data.SqlDbType.Decimal)
                {
                    Value = entity.TotalPurchasesAmount
                };
                command.Parameters.Add(customerFirstNameParam);
                command.Parameters.Add(customerLastNameParam);
                command.Parameters.Add(customerPhoneNumberParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(customerTotalPurchasesAmountParam);
                command.ExecuteNonQuery();
            }
        }


        public Customer Read(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Customers] WHERE CustomerId = @CustomerId", connection);
                var customerIDParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(customerIDParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            TotalPurchasesAmount = Convert.ToDecimal(reader["TotalPurchasesAmount"])
                        };
                    }
                }
            }
            return null;
        }


        public void Update(Customer entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [Customers] SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Email = @Email, TotalPurchasesAmount = @TotalPurchasesAmount  WHERE CustomerId = @CustomerId", connection);
                var customerIdParam = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var customerFirstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                var customerLastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.LastName
                };
                var customerPhoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = entity.PhoneNumber
                };
                var customerEmailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 100)
                {
                    Value = entity.Email
                };
                var customerTotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Decimal)
                {
                    Value = entity.TotalPurchasesAmount
                };
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(customerFirstNameParam);
                command.Parameters.Add(customerLastNameParam);
                command.Parameters.Add(customerPhoneNumberParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(customerTotalPurchasesAmountParam);
                command.ExecuteNonQuery();

            }
        }


        public void Delete(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command1 = new SqlCommand("DELETE FROM [Addresses] WHERE CustomerId = @CustomerId", connection);
                var command2 = new SqlCommand("DELETE FROM [Notes] WHERE CustomerId = @CustomerId", connection);
                var command3 = new SqlCommand("DELETE FROM [Customers] WHERE CustomerId = @CustomerId", connection);
                var customerIdParam1 = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
                {
                    Value = entityID
                };
                var customerIdParam2 = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
                {
                    Value = entityID
                };
                var customerIdParam3 = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
                {
                    Value = entityID
                };
                command1.Parameters.Add(customerIdParam1);
                command1.ExecuteNonQuery();
                command2.Parameters.Add(customerIdParam2);
                command2.ExecuteNonQuery();
                command3.Parameters.Add(customerIdParam3);
                command3.ExecuteNonQuery();
            }
        }


        public int GetId()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT CustomerId FROM Customers", connection);
                var reader = command.ExecuteReader();
                int lastCustomerId = 0;
                while (reader.Read())
                {
                    lastCustomerId = Convert.ToInt32(reader["CustomerId"]);
                }
                return lastCustomerId;
            }
        }


        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command1 = new SqlCommand(
                    "DELETE FROM Notes",
                    connection);
                command1.ExecuteNonQuery();
                var command2 = new SqlCommand(
                    "DELETE FROM Addresses",
                    connection);
                command2.ExecuteNonQuery();
                var command3 = new SqlCommand(
                    "DELETE FROM Customers",
                    connection);
                command3.ExecuteNonQuery();
            }
        }


        public List<Customer> GetAll()
        {
            using (var connection = GetConnection())
            {
                var customers = new List<Customer>();
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Customers]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = (int)reader["CustomerId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            TotalPurchasesAmount = Convert.ToDecimal(reader["TotalPurchasesAmount"])
                        });
                    }
                }
                return customers;
            }
        }
    }
}
