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
    public partial class AddressDelete : System.Web.UI.Page
    {

        private IRepository<Addresses> _addressRepository;

        public AddressDelete()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressDelete(IRepository<Addresses> addressRepository)
        {
            _addressRepository = addressRepository;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void OnClickDelete(object sender, EventArgs e)
        {
            _addressRepository.Delete(Convert.ToInt32(Request.QueryString["addressId"]));
            Response.Redirect("~/AddressesList.aspx");
        }

        public void OnClickNo(object sender, EventArgs e)
        {
            Response.Redirect("~/AddressesList.aspx");
        }
    }
}