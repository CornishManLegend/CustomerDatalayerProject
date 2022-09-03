using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerDatalayerWebForms
{
    public partial class NotesList : System.Web.UI.Page
    {
        private IRepository<Notes> _noteRepository;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}