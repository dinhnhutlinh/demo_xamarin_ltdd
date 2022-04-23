using System;
using System.Windows.Input;
using Xamarin.Forms;
using NoteDemo.Database;
using NoteDemo.Models;
using NoteDemo.ViewModels;

namespace NoteDemo.ViewModels
{
    public class NoteViewModel : ViewModelBase
    {
        private readonly INoteRepository noteRepository;
        private Note note;

        public NoteViewModel(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;

            SaveNoteCommand = new Command(async () =>
            {
                await this.noteRepository.AddOrUpdateNote(Note);

                MessagingCenter.Send(this, "saveoccured");

                await Navigation.PopAsync();
            });

            DeleteNoteCommand = new Command(async () =>
             {
                 await this.noteRepository.DeleteNote(Note);

                 MessagingCenter.Send(this, "saveoccured");

                 await Navigation.PopAsync();
             });
        }

        public Note Note
        {
            get => note;
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveNoteCommand { get; set; }

        public ICommand DeleteNoteCommand { get; set; }
    }
}