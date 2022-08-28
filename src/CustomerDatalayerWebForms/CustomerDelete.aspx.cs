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
        private IRepository<Customers> _customerRepository;

        public CustomerDelete()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerDelete(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request["customerId"]);
            if (customerIdReq != 0)
            {
                if (!IsPostBack)
                {
                    var customer = _customerRepository.Read(customerIdReq);

                }
            }
        }

        public void OnClickDelete(object sender, EventArgs e)
        {
            _customerRepository.Delete(Convert.ToInt32(Request.QueryString["customerId"]));
            Response.Redirect("AllCustomersList.aspx");
        }

        public void OnClickNo(object sender, EventArgs e)
        {
            Response.Redirect("AllCustomersList.aspx");
        }
    }
}