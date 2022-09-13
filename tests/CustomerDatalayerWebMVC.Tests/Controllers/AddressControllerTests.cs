using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayerWebMVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Moq;
using PagedList;
using Castle.Core.Resource;
using CustomerDatalayer.Repositories;
using System.Dynamic;
using CustomerDatalayer.Services;

namespace CustomerDatalayerWebMVC.Tests.Controllers
{
    [TestClass]
    public class AddressControllerTests
    {
        [TestMethod]
        public void ShouldBeAbleToCreateAddressController()
        {
            var controller = new AddressController();
            Assert.IsNotNull(controller);
        }


        [TestMethod]
        public void ShouldBeAbleToCreateAddress()
        {
            var addressServiceMock = new Mock<IAddressService>();
            var addressController = new AddressController(addressServiceMock.Object);
            var result = addressController.Create(1, new Address()
            {
                AddressLine1 = "Mulholland Drive",
                AddressLine2 = "13/1",
                AddressType = AddrTypes.Billing,
                City = "Los Angeles",
                PostalCode = "90012",
                AddrState = "Washington",
                Country = "USA"
            }) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ShouldBeAbleToUpdateAddress()
        {
            var addressServiceMock = new Mock<IAddressService>();
            var addressController = new AddressController(addressServiceMock.Object);
            var result = addressController.Edit(1, 1, new Address()
            {
                AddressId = 1,
                AddressLine1 = "update",

            });

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ShouldBeAbleToDeleteAddress()
        {
            Address address = new Address()
            {

                AddressId = 1,
                CustomerId = 1,
                AddressLine1 = "Mulholland Drive",
                AddressLine2 = "13/1",
                AddressType = AddrTypes.Billing,
                City = "Los Angeles",
                PostalCode = "90012",
                AddrState = "Washington",
                Country = "USA"
            };

            var addressServiceMock = new Mock<IAddressService>();
            addressServiceMock.Setup(x => x.Create(address)).Returns(address);
            var addressController = new AddressController(addressServiceMock.Object);
            var result = addressController.Delete(1,1) as RedirectToRouteResult; 

            Assert.IsNotNull(result);
        }
    }
}
