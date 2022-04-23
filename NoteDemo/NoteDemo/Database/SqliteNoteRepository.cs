using NoteDemo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NoteDemo.Database
{
    public class SqliteNoteRepository : INoteRepository
    {
        private SQLiteAsyncConnection _connection;

        public async Task AddOrUpdateNote(Note note)
        {
            if (note.Id != 0)
            {

                _ = await _connection.UpdateAsync(note);
            }
            else
            {
                _ = await _connection.InsertAsync(note);
            }
        }

        public async Task DeleteNote(Note note) => _ = await _connection.DeleteAsync(note);

        public Task<List<Note>> GetNotes()
            => _connection.Table<Note>().ToListAsync();

        public async Task Initialize()
        {
            if (_connection != null) return;

             _connection =  new SQLiteAsyncConnection(
                Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "note.db"));

           await _connection.CreateTableAsync<Note>();
        }       
    }
}
