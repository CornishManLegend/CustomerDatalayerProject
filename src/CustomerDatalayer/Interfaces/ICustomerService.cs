using CustomerDatalayer.BusinessEntities;
using System.Collections.Generic;
using System.Deployment.Internal;

namespace CustomerLibrary.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);
        Customer Create(Customer customer);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);
        IReadOnlyCollection<Customer> GetCustomers();
        IReadOnlyCollection<Address> GetAllAddresses(int id);
        IReadOnlyCollection<Note> GetAllNotes(int id);

    }
}