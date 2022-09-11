using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Integration.Tests
{
    public class AddressRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new AddressRepository();
            repository.DeleteAll();
        }

        public Address CreateMockAddress()
        {
            var repository = new CustomerRepository();
            Customer customer = new Customer
            {
                FirstName = "Maria",
                LastName = "Waynenen",
                PhoneNumber = "123456789444444",
                Email = "mariaWaynenen@gmail.com",
                TotalPurchasesAmount = 10
            };
            repository.Create(customer);


            var addressRepository = CreateAddressRepository();
            Address address = new Address
            {
                CustomerId = addressRepository.GetCustomerId(),
                AddressLine1 = "Mulholland Drive",
                AddressLine2 = "13/1",
                AddressType = AddrTypes.Billing,
                City = "Los Angeles",
                PostalCode = "90012",
                AddrState = "Washington",
                Country = "USA"
            };
            addressRepository.Create(address);

            return address;
        }

        public AddressRepository CreateAddressRepository()
        {
            return new AddressRepository();
        }

    }
}
