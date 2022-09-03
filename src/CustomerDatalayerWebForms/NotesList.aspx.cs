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
    public partial class NotesList : System.Web.UI.Page
    {
        //private IRepository<Notes> _noteRepository;
        private NoteRepository _noteRepository;

        public List<Notes> Notes { get; set; }

        public NotesList()
        {
            _noteRepository = new NoteRepository();
        }

        //public NotesList(IRepository<Notes> noteRepository)
        //{
        //    _noteRepository = noteRepository;
        //}

        //public void LoadAllNotesFromDatabase()
        //{
        //    Notes = _noteRepository.GetAll();
        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    LoadAllNotesFromDatabase();
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request["customerId"]);

            Notes = _noteRepository.GetCustomerNotes(customerIdReq);
        }

        public void OnClickAddNote(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            Response.Redirect($"NoteEdit?customerId={customerIdReq}");
        }

    }
}