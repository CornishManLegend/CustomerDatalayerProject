using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.BusinessEntities
{
    public class Note
    {
        public int NoteId { get; set; }
        public int CustomerId { get; set; }
        public string NoteRecord { get; set; }
    }
}
