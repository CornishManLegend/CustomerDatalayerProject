using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Repositories
{

    public class AddressRepository : BaseRepository, IRepository<Address>
    {
        public void Create(Address entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Addresses(CustomerId, AddressLine1, AddressLine2, AddressType, City, PostalCode, AddrState, Country)" +
                    "VALUES (@CustomerId, @AddressLine1, @AddressLine2, @AddressType, @City, @PostalCode, @AddrState, @Country)",
                    connection);
                var addressCustomerIDParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var addressAddressLineParam = new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine1
                };
                var addressAddressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine2
                };
                var addressAddressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 10)
                {
                    Value = entity.AddressType
                };
                var addressCityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = entity.City
                };
                var addressPostalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = entity.PostalCode
                };
                var addressStateNameParam = new SqlParameter("@AddrState", SqlDbType.NVarChar, 20)
                {
                    Value = entity.AddrState
                };
                var addressCountryNameParam = new SqlParameter("@Country", SqlDbType.NVarChar)
                {
                    Value = entity.Country
                };
                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressAddressLineParam);
                command.Parameters.Add(addressAddressLine2Param);
                command.Parameters.Add(addressAddressTypeParam);
                command.Parameters.Add(addressCityParam);
                command.Parameters.Add(addressPostalCodeParam);
                command.Parameters.Add(addressStateNameParam);
                command.Parameters.Add(addressCountryNameParam);
                command.ExecuteNonQuery();
            }

        }


        public void Delete(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Addresses WHERE AddressId = @AddressId", connection);
                var addressIDParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(addressIDParam);
                command.ExecuteNonQuery();
            }
        }

        public Address Read(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Addresses WHERE AddressId = @AddressId", connection);
                var addressIDParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(addressIDParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Address
                        {
                            AddressId = Convert.ToInt32(reader["AddressId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            AddressLine1 = reader["AddressLine1"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressTypeAsString = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            AddrState = reader["AddrState"].ToString(),
                            Country = reader["Country"].ToString()
                        };
                    }

                }
            }
            return null;
        }


        public void Update(Address entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Addresses SET CustomerId = @CustomerId, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, AddressType = @AddressType, City = @City, PostalCode = @PostalCode, AddrState = @AddrState, Country = @Country WHERE AddressId = @AddressId", connection);
                var addressAddressIdParam = new SqlParameter("@AddressId", System.Data.SqlDbType.Int)
                {
                    Value = entity.AddressId
                };
                var addressCustomerIDParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var addressAddressLineParam = new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine1
                };
                var addressAddressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine2
                };
                var addressAddressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 10)
                {
                    Value = entity.AddressType
                };
                var addressCityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = entity.City
                };
                var addressPostalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = entity.PostalCode
                };
                var addressStateNameParam = new SqlParameter("@AddrState", SqlDbType.NVarChar, 20)
                {
                    Value = entity.AddrState
                };
                var addressCountryNameParam = new SqlParameter("@Country", SqlDbType.NVarChar)
                {
                    Value = entity.Country
                };
                command.Parameters.Add(addressAddressIdParam);
                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressAddressLineParam);
                command.Parameters.Add(addressAddressLine2Param);
                command.Parameters.Add(addressAddressTypeParam);
                command.Parameters.Add(addressCityParam);
                command.Parameters.Add(addressPostalCodeParam);
                command.Parameters.Add(addressStateNameParam);
                command.Parameters.Add(addressCountryNameParam);
                command.ExecuteNonQuery();
            }
        }


        public int GetCustomerId()
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



        public int GetId()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT AddressId FROM Addresses", connection);
                var reader = command.ExecuteReader();
                int lastAddressId = 0;
                while (reader.Read())
                {
                    lastAddressId = Convert.ToInt32(reader["AddressId"]);
                }
                return lastAddressId;
            }
        }


        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [Addresses]", connection);
                command.ExecuteNonQuery();
            }
        }


        public List<Address> GetAll()
        {
            using (var connection = GetConnection())
            {
                var addresses = new List<Address>();
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Addresses]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address
                        {
                            AddressId = Convert.ToInt32(reader["AddressId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            AddressLine1 = reader["AddressLine1"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressTypeAsString = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            AddrState = reader["AddrState"].ToString(),
                            Country = reader["Country"].ToString()
                        });
                    }
                }
                return addresses;
            }
        }


    }
}
