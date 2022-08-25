using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var repository = new CustomerRepository();
            var customers = new Customers()
            {
                FirstName = "John",
                LastName = "Wayne",
                PhoneNumber = "+123456789111111",
                Email = "johnWayne@gmail.com",
                TotalPurchasesAmount = 11,
            };
            repository.Create(customers);
        }


        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateCustomerRepository();
            Assert.NotNull(repository.Read(repository.GetCustomerId()));
        }


        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            Fixture.DeleteAll();
            var customers = Fixture.CreateMockCustomer();
            var repository = Fixture.CreateCustomerRepository();
            customers.PhoneNumber = "+123456789555554";

            repository.Update(customers);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateCustomerRepository();

            repository.Delete(1);
        }
    }


    public class CustomersRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new CustomerRepository();
            repository.DeleteAll();
        }
        public Customers CreateMockCustomer()
        {
            var customers = new Customers
            {
                FirstName = "Maria",
                LastName = "Wayne",
                PhoneNumber = "+123456789444444",
                Email = "mariaWayne@gmail.com",
                TotalPurchasesAmount = 100,
            };
            var customerRepository = new CustomerRepository();
            customerRepository.Create(customers);
            return customers;
        }
        public CustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository();
        }
    }

}
