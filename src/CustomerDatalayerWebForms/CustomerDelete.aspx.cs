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
    public partial class CustomerDelete : System.Web.UI.Page
    {
        private IRepository<Customer> _customerRepository;

        public CustomerDelete()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerDelete(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void OnClickDelete(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request["customerId"]);
            _customerRepository.Delete(customerIdReq);
            Response.Redirect("~/");
        }

        public void OnClickNo(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}