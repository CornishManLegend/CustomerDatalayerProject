using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerDatalayerWebForms
{
    public partial class NoteDelete : System.Web.UI.Page
    {
        private IRepository<Notes> _noteRepository;
        public NoteDelete()
        {
            _noteRepository = new NoteRepository();
        }

        public NoteDelete(IRepository<Notes> noteRepository)
        {
            _noteRepository = noteRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void OnClickDelete(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            var noteIdReq = Convert.ToInt32(Request.QueryString["noteId"]);
            _noteRepository.Delete(noteIdReq);
            Response.Redirect($"~/NotesList?customerId={customerIdReq}");
        }

        public void OnClickNo(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            Response.Redirect($"~/NotesList?customerId={customerIdReq}");
        }
    }
}