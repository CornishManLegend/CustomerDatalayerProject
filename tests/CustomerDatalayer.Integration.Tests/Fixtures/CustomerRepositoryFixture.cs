using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Integration.Tests
{
    public class CustomersRepositoryFixture
    {
        public Customer CreateMockCustomer()
        {
            List<Address> adressList = new List<Address>();
            Address address = new Address
            {
                CustomerId = 1,
                AddressLine1 = "Mulholland Drive",
                AddressLine2 = "13/1",
                AddressType = AddrTypes.Billing,
                City = "Los Angeles",
                PostalCode = "90012",
                AddrState = "Washington",
                Country = "USA"
            };
            adressList.Add(address);


            List<Note> notesList = new List<Note>();
            Note note = new Note
            {
                NoteId = 1,
                CustomerId = 1,
                NoteRecord = "some note"
            };
            notesList.Add(note);

            var repository = new CustomerRepository();
            Customer customer = new Customer
            {
                FirstName = "Maria",
                LastName = "Waynenen",
                Addresses = adressList,
                Notes = notesList,
                PhoneNumber = "123456789444444",
                Email = "mariaWaynenen@gmail.com",
                TotalPurchasesAmount = 10
            };
            repository.Create(customer);
            return customer;

        }

        public CustomerRepository CreateCustomerRepository() => new CustomerRepository();
    }
}
