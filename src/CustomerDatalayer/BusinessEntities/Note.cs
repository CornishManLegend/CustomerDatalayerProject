using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.BusinessEntities
{
    public class Note
    {
        [DisplayName("Note ID")]
        public int NoteId { get; set; }

        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [DisplayName("Note Record")]
        [Required]
        public string NoteRecord { get; set; }
    }
}
