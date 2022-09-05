using CustomerDatalayer.BusinessEntities;
using System.Collections.Generic;
using System.Deployment.Internal;

namespace CustomerLibrary.Interfaces
{
    public interface ICustomerService
    {
        CustomerClass GetCustomer(int id);
        CustomerClass Create(CustomerClass customer);
        void DeleteCustomer(int id);
        void UpdateCustomer(CustomerClass customer);
        IReadOnlyCollection<CustomerClass> GetCustomers();
        IReadOnlyCollection<Address> GetAllAddresses(int id);
        IReadOnlyCollection<Note> GetAllNotes(int id);

    }
}