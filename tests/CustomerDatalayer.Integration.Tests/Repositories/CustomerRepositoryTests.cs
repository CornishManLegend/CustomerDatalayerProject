using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerDatalayer.Integration.Tests
{

    public class CustomerRepositoryTests
    {
        public CustomersRepositoryFixture Fixture => new CustomersRepositoryFixture();


        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = new CustomerRepository();
            Assert.NotNull(repository);
        }


        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customer = Fixture.CreateMockCustomer();
            Assert.NotNull(customer);
            Assert.Equal("Maria", customer.FirstName);
            Assert.Equal("Waynenen", customer.LastName);
            Assert.Equal("mariaWaynenen@gmail.com", customer.Email);
            Assert.Equal("123456789444444", customer.PhoneNumber);
            Assert.Equal(10, customer.TotalPurchasesAmount);
        }


        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            Fixture.CreateMockCustomer();
            var repository = Fixture.CreateCustomerRepository();
            var readedCustomer = repository.Read(repository.GetId());
            Assert.NotNull(readedCustomer);
            Assert.Equal("Maria", readedCustomer.FirstName);
            Assert.Equal("Waynenen", readedCustomer.LastName);
            Assert.Equal("mariaWaynenen@gmail.com", readedCustomer.Email);
            Assert.Equal("123456789444444", readedCustomer.PhoneNumber);
            Assert.Equal(10, readedCustomer.TotalPurchasesAmount);

        }


        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            Fixture.CreateMockCustomer();
            var repository = Fixture.CreateCustomerRepository();
            var readLastEddedCustomer = repository.Read(repository.GetId());
            readLastEddedCustomer.LastName = "Nona";
            repository.Update(readLastEddedCustomer);
            var result = repository.Read(repository.GetId()).LastName;
            Assert.Equal("Nona", result);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var repository = Fixture.CreateCustomerRepository();
            var readLastEddedCustomer = repository.Read(repository.GetId());
            int lastEddedCustomerID = readLastEddedCustomer.CustomerId;
            repository.Delete(lastEddedCustomerID);
            Assert.Null(repository.Read(lastEddedCustomerID));
        }


        [Fact]
        public void ShouldBeAbleToGetAllCustomers()
        {
            var repository = Fixture.CreateCustomerRepository();
            repository.DeleteAll();
            Fixture.CreateMockCustomer();
            Fixture.CreateMockCustomer();
            Fixture.CreateMockCustomer();
            var allCustomers = repository.GetAll();
            foreach (Customer customer in allCustomers)
            {
                Assert.Equal("123456789444444", customer.PhoneNumber);
            }
        }


        [Fact]
        public void ShouldBeAbleToDeleteAllCustomers()
        {
            var repository = Fixture.CreateCustomerRepository();
            int lastEddedCustomerID = repository.GetId();
            repository.DeleteAll();
            Assert.Null(repository.Read(lastEddedCustomerID));
        }


    }

}
