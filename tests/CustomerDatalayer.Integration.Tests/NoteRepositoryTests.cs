using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static CustomerDatalayer.Integration.Tests.AddressRepositoryTests;

namespace CustomerDatalayer.Integration.Tests
{
    public class NoteRepositoryTests
    {
        public NoteRepositoryFixture Fixture => new NoteRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateNoteRepository()
        {
            var repository = new NoteRepository();
            Assert.NotNull(repository);
        }


        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            var note = Fixture.CreateMockNote();
            Assert.Equal("Note Record", note.NoteRecord);
        }


        [Fact]
        public void ShouldBeAbleToReadNote()
        {
            Fixture.CreateMockNote();
            var repository = Fixture.CreateNoteRepository();
            Assert.NotNull(repository.Read(repository.GetId()));
        }


        [Fact]
        public void ShouldBeAbleToReturnNullWhenReadNoteWithNullId()
        {
            Fixture.CreateMockNote();
            var repository = Fixture.CreateNoteRepository();
            Assert.Null(repository.Read(0));
        }


        [Fact]
        public void ShouldBeAbleToUpdateNote()
        {
            Fixture.CreateMockNote();
            var repository = Fixture.CreateNoteRepository();
            var lastAddedNoteId = repository.GetId();
            var lastAddedNote = repository.Read(lastAddedNoteId);
            lastAddedNote.NoteRecord = "Canada (note)";
            repository.Update(lastAddedNote);
            Assert.Equal("Canada (note)", repository.Read(lastAddedNoteId).NoteRecord);
        }


        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            Fixture.CreateMockNote();
            var repository = Fixture.CreateNoteRepository();
            var lastAddedNoteId = repository.GetId();
            repository.Delete(lastAddedNoteId);
            Assert.Null(repository.Read(lastAddedNoteId));

        }


        [Fact]
        public void ShouldBeAbleToGetAllNotes()
        {
            var repository = Fixture.CreateNoteRepository();
            Fixture.DeleteAll();
            Fixture.CreateMockNote();
            Fixture.CreateMockNote();
            Fixture.CreateMockNote();
            var allNotes = repository.GetAll();
            foreach (Note note in allNotes)
            {
                Assert.Equal("Note Record", note.NoteRecord);
            }
        }



        [Fact]
        public void ShouldBeAbleToGetCustomerNotes()
        {
            Fixture.CreateMockNote();
            var repository = Fixture.CreateNoteRepository();
            var lastAddedCustomerNotes = repository.GetCustomerNotes(repository.GetCustomerId());
            foreach (Note note in lastAddedCustomerNotes)
            {
                Assert.Equal("Note Record", note.NoteRecord);
            }
        }


        [Fact]
        public void ShouldBeAbleToDeleteAllNotes()
        {
            var repository = Fixture.CreateNoteRepository();
            int lastAddedNoteId = repository.GetId();
            repository.DeleteAll();
            Assert.Null(repository.Read(lastAddedNoteId));
        }

    }

    public class NoteRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new NoteRepository();
            repository.DeleteAll();
        }

        public Note CreateMockNote()
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


            var noteRepository = this.CreateNoteRepository();
            Note note = new Note
            {
                CustomerId = noteRepository.GetCustomerId(),
                NoteRecord = "Note Record",
            };
            noteRepository.Create(note);

            return note;
        }

        public NoteRepository CreateNoteRepository()
        {
            return new NoteRepository();
        }

    }
}
