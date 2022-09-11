using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.BusinessEntities
{
    public class Address
    {
        [DisplayName("Address ID")]
        public int AddressId { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Address Line1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [DisplayName("Address Line2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Address Type")]
        public string AddressTypeAsString
        {
            get
            {
                return this.AddressType.ToString();
            }
            set
            {
                AddressType = (AddrTypes)Enum.Parse(typeof(AddrTypes), value, true);
            }
        }

        public AddrTypes AddressType { get; set; }

        [DisplayName("City")]
        public string City { get; set; } = string.Empty;

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [DisplayName("State")]
        public string AddrState { get; set; } = string.Empty;

        [DisplayName("Country")]
        public string Country { get; set; } = string.Empty;
    }

}
