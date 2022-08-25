using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.BusinessEntities
{
    public class Notes
    {
        public int NoteId { get; set; }
        public int CustomerId { get; set; }
        public string Note { get; set; }
    }
}
