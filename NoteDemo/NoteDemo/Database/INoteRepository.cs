using NoteDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteDemo.Database
{
    public interface INoteRepository
    {
        Task Initialize();
        Task<List<Note>> GetNotes();
        Task AddOrUpdateNote(Note note);
        Task DeleteNote(Note note);
    }
}
