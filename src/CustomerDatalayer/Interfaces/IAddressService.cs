using CustomerDatalayer.BusinessEntities;
using System.Collections.Generic;


namespace CustomerDatalayer.Interfaces
{
    public interface IAddressService
    {
        Address GetAddress(int id);
        Address Create(Address address);
        void Update(Address address);
        void Delete(int id);
        IReadOnlyCollection<Address> GetAddresses(int id);
    }
}