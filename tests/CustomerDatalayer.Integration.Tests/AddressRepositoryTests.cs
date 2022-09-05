using Castle.Core.Resource;
using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using System.Net;
using Xunit;

namespace CustomerDatalayer.Integration.Tests
{
    public class AddressRepositoryTests
    {
        public AddressRepositoryFixture Fixture => new AddressRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var repository = new AddressRepository();
            Assert.NotNull(repository);
        }


        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var address = Fixture.CreateMockAddress();
            Assert.Equal("Mulholland Drive", address.AddressLine1);
            Assert.Equal("13/1", address.AddressLine2);
            Assert.Equal("Billing", address.AddressTypeAsString);
            Assert.Equal("Los Angeles", address.City);
            Assert.Equal("90012", address.PostalCode);
            Assert.Equal("Washington", address.AddrState);
            Assert.Equal("USA", address.Country);
        }


        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            Fixture.CreateMockAddress();
            var repository = Fixture.CreateAddressRepository();
            Assert.NotNull(repository.Read(repository.GetId()));
        }


        [Fact]
        public void ShouldBeAbleToReturnNullWhenReadAddressWithNullId()
        {
            Fixture.CreateMockAddress();
            var repository = Fixture.CreateAddressRepository();
            Assert.Null(repository.Read(0));
        }


        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            Fixture.CreateMockAddress();
            var repository = Fixture.CreateAddressRepository();
            var lastAddedAddressId = repository.GetId();
            var lastAddedAddress = repository.Read(lastAddedAddressId);
            lastAddedAddress.Country = "Canada";
            repository.Update(lastAddedAddress);
            Assert.Equal("Canada", repository.Read(lastAddedAddressId).Country);
        }


        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            //Fixture.DeleteAll();
            Fixture.CreateMockAddress();
            var repository = Fixture.CreateAddressRepository();
            var lastAddedAddressId = repository.GetId();
            repository.Delete(lastAddedAddressId);
            Assert.Null(repository.Read(lastAddedAddressId));

        }


        [Fact]
        public void ShouldBeAbleToDeleteAllAddresses()
        {
            var repository = Fixture.CreateAddressRepository();
            int lastAddedAddressId = repository.GetId();
            repository.DeleteAll();
            Assert.Null(repository.Read(lastAddedAddressId));
        }


        [Fact]
        public void ShouldBeAbleToGetAllCustomers()
        {
            var repository = Fixture.CreateAddressRepository();
            Fixture.DeleteAll();
            Fixture.CreateMockAddress();
            Fixture.CreateMockAddress();
            Fixture.CreateMockAddress();
            var allAddresses = repository.GetAll();
            foreach (Address address in allAddresses)
            {
                Assert.Equal("13/1", address.AddressLine2);
            }
        }




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


                var addressRepository = this.CreateAddressRepository();
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

}