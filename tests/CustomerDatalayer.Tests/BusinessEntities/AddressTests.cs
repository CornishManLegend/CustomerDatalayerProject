using CustomerDatalayer.BusinessEntities;
using System;
using System.Collections.Generic;

namespace CustomerDatalayer.Tests.BusinessEntities
{
    public class AddressTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            Address addressNumber1 = new Address()
            {
                AddressLine1 = "Mulholland Drive",
                AddressLine2 = "13/1",
                AddressType = AddrTypes.Billing,
                City = "Los Angeles",
                PostalCode = "90012",
                AddrState = "Washington",
                Country = "USA"
            };
            Assert.NotNull(addressNumber1);
            Assert.Equal("Mulholland Drive", addressNumber1.AddressLine1);
            Assert.Equal("13/1", addressNumber1.AddressLine2);
            Assert.Equal("Billing", addressNumber1.AddressTypeAsString);
            Assert.Equal("Los Angeles", addressNumber1.City);
            Assert.Equal("90012", addressNumber1.PostalCode);
            Assert.Equal("Washington", addressNumber1.AddrState);
            Assert.Equal("USA", addressNumber1.Country);
        }

    }
}
