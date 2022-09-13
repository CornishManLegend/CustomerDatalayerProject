using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        [RegularExpression(@"^[1-9]\d{14,14}$", ErrorMessage = "Incorrect the phone number format")]
        public string PhoneNumber { get; set; } = string.Empty;

        [DisplayName("Email")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Incorrect the email format")]
        public string Email { get; set; } = string.Empty;
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Note> Notes { get; set; } = new List<Note>();

        [DisplayName("Total Purchases Amount")]
        [RegularExpression(@"^[\+]?[0-9]*(\.[0-9]+)?", ErrorMessage = "The value cannot be negative")]
        public decimal? TotalPurchasesAmount { get; set; } = 0;
    }
}
