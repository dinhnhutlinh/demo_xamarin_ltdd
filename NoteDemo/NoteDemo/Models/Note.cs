using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NoteDemo.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }

        public Note()
        {
            CreateAt = DateTime.Now;
        }       
    }
}
