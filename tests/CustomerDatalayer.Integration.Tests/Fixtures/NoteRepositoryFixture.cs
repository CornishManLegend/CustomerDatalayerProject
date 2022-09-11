using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Integration.Tests
{

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


            var noteRepository = CreateNoteRepository();
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
