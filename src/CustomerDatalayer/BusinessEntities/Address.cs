using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(100)]
        public string AddressLine1 { get; set; } = string.Empty;

        [DisplayName("Address Line2")]
        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [DisplayName("Address Type")]
        [Required]
        [RegularExpression(@"^(Shipping|Billing)$", ErrorMessage = "The Address Type should be Shipping or Billing")]
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
        [Required]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [DisplayName("Postal Code")]
        [Required]
        [RegularExpression(@"^[0-9]{0,6}$", ErrorMessage = "The Postal Code cannot be longer than 6 characters. Only integers")]
        public string PostalCode { get; set; } = string.Empty;

        [DisplayName("State")]
        [Required]
        [StringLength(20)]
        public string AddrState { get; set; } = string.Empty;

        [DisplayName("Country")]
        [Required]
        [RegularExpression(@"^(USA|Canada)$", ErrorMessage = "The Country name can be either USA or Canada")]
        public string Country { get; set; } = string.Empty;
    }

}
