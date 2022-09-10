using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using CustomerDatalayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerDatalayerWebMVC.Controllers
{
    public class NoteController : Controller
    {
        private INoteService _noteService;

        public NoteController()
        {
            _noteService = new NoteService();
        }

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // GET: Note/Create
        public ActionResult Create(int customerId)
        {
            return View();
        }

        // POST: Note/Create
        [HttpPost]
        public ActionResult Create(int customerId, Note note)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View();
            }
            _noteService.Create(note);

            return RedirectToAction("Details", "Customer", new { id = customerId });
        }

        // GET: Note/Edit/5
        public ActionResult Edit(int id)
        {
            var note = _noteService.GetNote(id);
            return View(note);
        }

        // POST: Note/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, int? customerId, Note note)
        {
            note.NoteId = id;
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View(note);
            }
            _noteService.Update(note);

            return RedirectToAction("Details", "Customer", new { id = customerId });
        }

        // GET: Note/Delete/5
        public ActionResult Delete(int id)
        {
            var note = _noteService.GetNote(id);
            return View(note);
        }

        // POST: Note/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int? customerId)
        {
            _noteService.Delete(id);

            if (customerId.HasValue)
            {
                return RedirectToAction("Details", "Customer", new { id = customerId });
            }
            else return View();
        }
    }
}
