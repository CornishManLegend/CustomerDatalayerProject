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
    public class NoteControllerTests
    {
        [TestMethod]
        public void ShouldBeAbleToCreateNoteController()
        {
            var controller = new NoteController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ShouldBeAbleToCreateNote()
        {
            var noteControllerMock = new Mock<INoteService>();
            var noteController = new NoteController(noteControllerMock.Object);
            var result = noteController.Create(1, new Note()
            {
                NoteId = 1,
                CustomerId = 1,
                NoteRecord = "new note"
            }) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldBeAbleToUpdateNote()
        {
            var noteControllerMock = new Mock<INoteService>();
            var noteController = new NoteController(noteControllerMock.Object);
            var result = noteController.Edit(1, 1, new Note()
            {
                NoteId = 1,
                CustomerId = 1,
                NoteRecord = "some note"
            });

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ShouldBeAbleToDeleteNote()
        {
            Note address = new Note()
            {
                NoteId = 1,
                CustomerId = 1,
                NoteRecord = "some note"
            };

            var noteControllerMock = new Mock<INoteService>();
            noteControllerMock.Setup(x => x.Create(address)).Returns(address);
            var noteController = new NoteController(noteControllerMock.Object);
            var result = noteController.Delete(1, 1) as RedirectToRouteResult;

            Assert.IsNotNull(result);
        }
    }
}
