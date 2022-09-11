using System;
using System.Collections.Generic;
using CustomerDatalayer.BusinessEntities;

namespace CustomerDatalayer.Tests.BusinessEntities
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldCreateCustomer()
        {
            Customer newCustomer = new Customer()
            {
                FirstName = "John",
                LastName = "Wayne",
                PhoneNumber = "123456789444444",
                Email = "johnWayne@gmail.com",
                TotalPurchasesAmount = 10
            };
            Assert.Equal("John", newCustomer.FirstName);
            Assert.Equal("Wayne", newCustomer.LastName);
            Assert.Equal("123456789444444", newCustomer.PhoneNumber);
            Assert.Equal("johnWayne@gmail.com", newCustomer.Email);
            Assert.Equal(10, newCustomer.TotalPurchasesAmount);
        }

    }
}