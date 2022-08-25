using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;

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
            var repository = new AddressRepository();
            var address = new Addresses()
            {
                CustomerId = repository.GetCustomerId(),
                AddressLine1 = "Mulholland Drive",
                AddressLine2 = "13/1",
                AddressType = "Shipping",
                City = "Los Angeles",
                PostalCode = "90012",
                AddrState = "California",
                Country = "USA"
            };
            repository.Create(address); 
        }


        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var repository = Fixture.CreateAddressRepository();
            Assert.NotNull(repository.Read(repository.GetAddressId()));
        }


        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var repository = Fixture.CreateAddressRepository();
            var addresses = new Addresses()
            {
                AddressId = repository.GetAddressId(),
                CustomerId = repository.GetCustomerId(),
                AddressLine1 = "AddressLine1",
                AddressLine2 = "AddressLine2",
                AddressType = "Billing",
                City = "Ostin",
                PostalCode = "77777",
                AddrState = "Texas",
                Country = "USA"
            };
            repository.Update(addresses);
        }


        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateAddressRepository();

            repository.Delete(1);
        }

    }


    public class AddressRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new AddressRepository();
            repository.DeleteAll();
        }

        public Addresses CreateMockAddress()
        {
            var address = new Addresses()
            {
                CustomerId = 4,
                AddressLine1 = "AddressLine1",
                AddressLine2 = "AddressLine2",
                AddressType = "Billing",
                City = "Ostin",
                PostalCode = "77777",
                AddrState = "Texas",
                Country = "USA"
            };
            var addressRepository = new AddressRepository();
            addressRepository.Create(address);
            return address;
        }

        public AddressRepository CreateAddressRepository()
        {
            return new AddressRepository();
        }
    }


}