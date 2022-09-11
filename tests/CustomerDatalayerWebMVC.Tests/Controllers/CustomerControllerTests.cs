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

namespace CustomerDatalayerWebMVC.Tests.Controllers
{

    [TestClass]
    public class CustomerControllerTests
    {

        [TestMethod]
        public void ShouldBeAbleToCreateCustomerController()
        {
            var controller = new CustomerController();
            Assert.IsNotNull(controller);
        }


        //[TestMethod]
        //public void ShouldReturnListOfCustomers()
        //{
        //    var controller = new CustomerController();
        //    var customersResult = controller.Index(1);
        //    var customersView = customersResult as ViewResult;
        //    var customerModel = customersView.Model as PagedList<Customer>;
        //    Assert.IsTrue(customerModel.Count != 0);
        //}


        //[TestMethod]
        //public void ShouldBeAbleToCreateRedirect()
        //{
        //    var customerController = new CustomerController();
        //    var result = customerController.Create(1, new Customer()
        //    {
        //        FirstName = "testJohn",
        //        LastName = "testWayne",
        //        PhoneNumber = "123456789111111",
        //        Email = "johnWayne@gmail.com",
        //        TotalPurchasesAmount = 1
        //    }) as RedirectToRouteResult;
        //    Assert.IsNotNull(result);
        //}


        [TestMethod]
        public void ShouldCreateCustomer()
        {
            var customerControllerMock = new Mock<ICustomerService>();
            var customerController = new CustomerController(customerControllerMock.Object);
            customerController.Create();
            var customer = new Customer()
            {
                FirstName = "John",
                LastName = "Wayne",
                Email = "johnWayne@gmail.com",
                PhoneNumber = "123456789111111",
                TotalPurchasesAmount = 10
            };
            var result = customerController.Create(1, customer) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            customerControllerMock.Verify(x => x.Create(customer));
        }


        [TestMethod]
        public void ShouldBeAbleToEditCustomer()
        {
            var customerControllerMock = new Mock<ICustomerService>();
            var customerController = new CustomerController(customerControllerMock.Object);
            var customer = new Customer()
            {
                FirstName = "John",
                LastName = "Wayne",
                Email = "johnWayne@gmail.com",
                PhoneNumber = "123456789111111",
                TotalPurchasesAmount = 10
            };
            customerController.Edit(5);
            var result = customerController.Edit(customer) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            customerControllerMock.Verify(x => x.UpdateCustomer(customer));
        }


        [TestMethod]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerControllerMock = new Mock<ICustomerService>();
            var customerController = new CustomerController(customerControllerMock.Object);
            customerController.Delete(10);
            var result = customerController.Delete(10, new Customer
            {
                FirstName = "John",
                LastName = "Wayne",
                PhoneNumber = "123456789111111",
                Email = "johnWayne@gmail.com",
                TotalPurchasesAmount = 10
            }) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            customerControllerMock.Verify(x => x.DeleteCustomer(10));
        }



    }
}
