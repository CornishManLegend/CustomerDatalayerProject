using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerDatalayerWebForms
{
    public partial class AddressManage : System.Web.UI.Page
    {
        private IRepository<Addresses> _addressRepository;
        private IRepository<Customers> _customerRepository;

        public AddressManage()
        {
            _addressRepository = new AddressRepository();
            _customerRepository = new CustomerRepository();
        }

        public AddressManage(IRepository<Addresses> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            var customers = _customerRepository.GetAll();
            foreach (var customer in customers)
            {
                customerId.Items.Add(customer.CustomerId.ToString());
            }

            addressType.Items.Add(Enum.GetName(typeof(AddrTypes), 0));
            addressType.Items.Add(Enum.GetName(typeof(AddrTypes), 1));

            var addressIdReq = Convert.ToInt32(Request["addressId"]);
            if (addressIdReq != 0)
            {
                if (!IsPostBack)
                {
                    var address = _addressRepository.Read(addressIdReq);

                    customerId.Text = Convert.ToString(address.CustomerId);
                    addressLine1.Text = address.AddressLine1;
                    addressLine2.Text = address.AddressLine2;
                    addressType.Text = address.AddressType.ToString();
                    city.Text = address.City;
                    postalCode.Text = address.PostalCode.ToString();
                    state.Text = address.AddrState;
                    country.Text = address.Country;

                }
            }
        }

        public void OnClickSave(object sender, EventArgs e)
        {
            var address = new Addresses()
            {
                AddressId = Convert.ToInt32(Request.QueryString["addressId"]),
                CustomerId = Convert.ToInt32(customerId.SelectedValue),
                AddressLine1 = addressLine1.Text,
                AddressLine2 = addressLine2.Text,
                AddressTypeAsString = addressType.Text,
                City = city.Text,
                PostalCode = postalCode.Text,
                AddrState = state.Text,
                Country = country.Text
            };


            if (Convert.ToInt32(Request.QueryString["addressId"]) == 0)
            {
                _addressRepository.Create(address);
            }
            else
            {
                _addressRepository.Update(address);
            }
            Response.Redirect("~/AddressesList.aspx");

        }
    }
}