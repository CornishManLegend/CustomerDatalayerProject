using CustomerDatalayer.BusinessEntities;
using System.Collections.Generic;

namespace CustomerDatalayer.Interfaces
{
    public interface INoteService
    {
        Note GetNote(int id);
        Note Create(Note note);
        void Update(Note note);
        void Delete(int id);
        IReadOnlyCollection<Note> GetNotes(int id);
    }
}