using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.BusinessEntities
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; }

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
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string AddrState { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }

}
