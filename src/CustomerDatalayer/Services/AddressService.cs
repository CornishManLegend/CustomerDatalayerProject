using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Services
{
    public class AddressService : IAddressService
    {
        private readonly AddressRepository _addressRepository;
        public AddressService()
        {
            _addressRepository = new AddressRepository();
        }
        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public Address GetAddress(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            Address address;

            address = _addressRepository.Read(id);

            if (address == null)
                throw new KeyNotFoundException();
            return address;
        }
        public Address Create(Address address)
        {
            _addressRepository.Create(address);
            return address;
        }
        public IReadOnlyCollection<Address> GetAddresses(int id)
        {
            var addresses = _addressRepository.GetCustomerAddresses(id);

            return addresses;
        }

        public void Delete(int id)
        {
            _addressRepository.Delete(id);
        }

        public void Update(Address address)
        {
            _addressRepository.Update(address);
        }
    }
}