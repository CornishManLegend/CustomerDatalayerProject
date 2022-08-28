using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerDatalayerWebForms
{

    public partial class CustomerManage : System.Web.UI.Page
    {

        private IRepository<Customers> _customerRepository;

        public CustomerManage()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerManage(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIDReq = Convert.ToInt32(Request["customerId"]);
            if (customerIDReq != 0)
            {
                if (!IsPostBack)
                {
                    var customer = _customerRepository.Read(customerIDReq);
                    firstName.Text = customer.FirstName;
                    lastName.Text = customer.LastName;
                    phoneNumber.Text = customer.PhoneNumber;
                    email.Text = customer.Email;
                    totalPurchasesAmount.Text = customer.TotalPurchasesAmount.ToString();
                }
            }

        }


        public void OnClickSave(object sender, EventArgs e)
        {
            var customer = new Customers()
            {
                CustomerId = Convert.ToInt32(Request.QueryString["customerId"]),
                FirstName = firstName?.Text,
                LastName = lastName?.Text,
                PhoneNumber = phoneNumber?.Text,
                Email = email?.Text,
                TotalPurchasesAmount = Convert.ToDecimal(totalPurchasesAmount?.Text)
            };
            _customerRepository.Update(customer);
            Response.Redirect("AllCustomersList.aspx");
        }
    }
}