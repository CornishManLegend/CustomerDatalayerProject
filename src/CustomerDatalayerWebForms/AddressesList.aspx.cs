using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerDatalayerWebForms
{
    public partial class AddressesList : System.Web.UI.Page
    {
        private IRepository<Addresses> _addressRepository;

        public List<Addresses> Addresses { get; set; }

        public AddressesList()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressesList(IRepository<Addresses> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void LoadAllAddressesFromDatabase()
        {
            Addresses = _addressRepository.GetAll();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllAddressesFromDatabase();
        }
    }
}