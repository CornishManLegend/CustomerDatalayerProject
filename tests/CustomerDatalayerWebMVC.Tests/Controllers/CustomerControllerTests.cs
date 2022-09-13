﻿using CustomerDatalayer.BusinessEntities;
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
    public class CustomerControllerTests
    {

        [TestMethod]
        public void ShouldBeAbleToCreateCustomerController()
        {
            var controller = new CustomerController();
            Assert.IsNotNull(controller);
        }


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
        public void ShouldBeAbleReturnListOfCustomers()
        {
            var controller = new CustomerController();
            var customersResult = controller.Index(1);
            var customersView = customersResult as ViewResult;
            var customerModel = customersView.Model as PagedList<Customer>;
            Assert.IsTrue(customerModel.Count != 0);
        }



        [TestMethod]
        public void ShouldBeAbleToCallCustomerCreatePage()
        {
            var controller = new CustomerController();
            var customersResult = controller.Create();
            var customersView = customersResult as ViewResult;

            Assert.IsNotNull(customersView);
        }


        [TestMethod]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var customerController = new CustomerController(customerServiceMock.Object);
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
            customerServiceMock.Verify(x => x.Create(customer));
        }


        [TestMethod]
        public void ShouldBeAbleToEditCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var customerController = new CustomerController(customerServiceMock.Object);
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
            customerServiceMock.Verify(x => x.UpdateCustomer(customer));
        }


        [TestMethod]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerServiceMock = new Mock<ICustomerService>();
            var customerController = new CustomerController(customerServiceMock.Object);
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
            customerServiceMock.Verify(x => x.DeleteCustomer(10));
        }


        [TestMethod]
        public void ShouldBeAbleToReturnCustomerDetails()
        {
            Customer customer = new Customer()
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Wayne",
                Email = "johnWayne@gmail.com",
                PhoneNumber = "123456789111111",
                TotalPurchasesAmount = 10
            };

            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(x => x.Create(customer)).Returns(customer);
            customerServiceMock.Setup(x => x.GetCustomer(customer.CustomerId)).Returns(customer);
            var customerController = new CustomerController(customerServiceMock.Object);
            var result = customerController.Details(customer.CustomerId);
            var resultView = result as ViewResult;

            var DetailsModel = resultView.Model;


            Assert.IsNotNull(resultView);
        }

    }
}
