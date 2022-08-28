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
    public partial class AllCustomersList : System.Web.UI.Page
    {

        private IRepository<Customers> _customerRepository;

        public List<Customers> Customers { get; set; }

        public AllCustomersList()
        {
            _customerRepository = new CustomerRepository();
        }

        public AllCustomersList(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public void LoadAllCustomersFromDatabase()
        {
            Customers = _customerRepository.GetAll();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllCustomersFromDatabase();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            var customerIDReq = Convert.ToInt32(Request.QueryString["customerId"]);
            _customerRepository.Delete(customerIDReq);
        }



        //protected void OnClickDelete(object sender, EventArgs e)
        //{
        //    var customerIDReq = Convert.ToInt32(Request.QueryString["customerId"]);
        //    _customerRepository.Delete(customerIDReq);
        //}

        //CustomerId = Convert.ToInt32(Request.QueryString["customerId"]),


    }
}