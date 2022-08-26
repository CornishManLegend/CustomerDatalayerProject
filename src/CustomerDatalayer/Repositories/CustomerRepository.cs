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
    public class CustomerRepository : BaseRepository, IRepository<Customers>
    {
        public void Create(Customers entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Customers(FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount)" +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount)",
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


        public Customers Read(int entityID)
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
                        return new Customers
                        {
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


        public void Update(Customers entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [Customers] SET FirstName = @FirstName WHERE CustomerId = @CustomerId", connection);
                var customerIDParam = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var customerFirstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                command.Parameters.Add(customerIDParam);
                command.Parameters.Add(customerFirstNameParam);
                command.ExecuteNonQuery();
            }
        }


        public void Delete(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [Customers] WHERE CustomerId = @CustomerId", connection);
                var customerIDParam = new SqlParameter("@CustomerId", System.Data.SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(customerIDParam);
                command.ExecuteNonQuery();
            }
        }


        public int GetId()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT CustomerId FROM Customers", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["CustomerId"]);
                }

            }
            return 0;
        }


        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM Customers",
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Customers> GetAll()
        {
            using (var connection = GetConnection())
            {
                var customers = new List<Customers>();
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Customers]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customers
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
