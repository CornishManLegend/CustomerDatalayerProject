using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using CustomerLibrary.Interfaces;

namespace CustomerLibrary.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly NoteRepository _noteRepository;
        private readonly AddressRepository _addressRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
            _noteRepository = new NoteRepository();
            _addressRepository = new AddressRepository();
        }
        public CustomerService(CustomerRepository customerRepository, NoteRepository noteRepository = null, AddressRepository addressRepository = null)
        {
            _customerRepository = customerRepository;
            _noteRepository = noteRepository ?? new NoteRepository();
            _addressRepository = addressRepository ?? new AddressRepository();
        }
        public Customer GetCustomer(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            Customer customer;

            customer = _customerRepository.Read(id);

            if (customer == null)
                throw new KeyNotFoundException();
            return customer;
        }
        public Customer Create(Customer customer)
        {
            _customerRepository.Create(customer);
            return customer;
        }
        public IReadOnlyCollection<Customer> GetCustomers()
        {
            var customers = _customerRepository.GetAll();

            return customers;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public IReadOnlyCollection<Address> GetAllAddresses(int id)
        {
            var addresses = _addressRepository.GetCustomerAddresses(id);
            return addresses;
        }

        public IReadOnlyCollection<Note> GetAllNotes(int id)
        {
            var notes = _noteRepository.GetCustomerNotes(id);
            return notes;
        }
    }
}