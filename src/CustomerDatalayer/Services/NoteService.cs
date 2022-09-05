using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Repositories;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Services
{
    public class NoteService : INoteService
    {
        private readonly NoteRepository _noteRepository;
        public NoteService()
        {
            _noteRepository = new NoteRepository();
        }
        public NoteService(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public Note GetNote(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            Note note;

            note = _noteRepository.Read(id);

            if (note == null)
                throw new KeyNotFoundException();
            return note;
        }
        public Note Create(Note note)
        {
            _noteRepository.Create(note);
            return note;
        }
        public IReadOnlyCollection<Note> GetNotes(int id)
        {
            var notes = _noteRepository.GetCustomerNotes(id);

            return notes;
        }

        public void Delete(int id)
        {
            _noteRepository.Delete(id);
        }

        public void Update(Note note)
        {
            _noteRepository.Update(note);
        }
    }
}