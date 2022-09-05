using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.BusinessEntities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Note> Notes { get; set; } = new List<Note>();
        public decimal? TotalPurchasesAmount { get; set; } = 0;
    }
}
