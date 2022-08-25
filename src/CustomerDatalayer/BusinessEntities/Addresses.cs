using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.BusinessEntities
{
    public class Addresses
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; }
        public string AddressType { get; set; } = "Unknown";
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string AddrState { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
