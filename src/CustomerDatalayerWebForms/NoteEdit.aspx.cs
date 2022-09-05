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
    public partial class NoteEdit : System.Web.UI.Page
    {
        private NoteRepository _noteRepository;

        public NoteEdit()
        {
            _noteRepository = new NoteRepository();
        }

        public NoteEdit(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            var noteIdReq = Convert.ToInt32(Request["noteId"]);
            


            if (!IsPostBack)
            {
                customerId.Text = customerIdReq.ToString();
                if (noteIdReq != 0)
                {
                    var noteItem = _noteRepository.Read(noteIdReq);
                    noteText.Text = noteItem.NoteRecord;
                }
            }

        }


        public void OnClickSave(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            var noteIdReq = Convert.ToInt32(Request.QueryString["noteId"]);

            var note = new Note()
            {
                NoteId = noteIdReq,
                CustomerId = customerIdReq,
                NoteRecord = noteText.Text
            };
            if (Request.QueryString["noteId"] == null)
                _noteRepository.Create(note);
            else _noteRepository.Update(note);

            Response.Redirect($"~/NotesList?customerId={customerIdReq}");

        }
    }
}