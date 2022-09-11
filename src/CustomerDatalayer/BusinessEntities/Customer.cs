using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.BusinessEntities
{
    public class Customer
    {
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Note> Notes { get; set; } = new List<Note>();

        [DisplayName("Total Purchases Amount")]
        public decimal? TotalPurchasesAmount { get; set; } = 0;
    }
}
