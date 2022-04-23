﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using NoteDemo.Database;
using NoteDemo.Models;
using NoteDemo.Views;
using NoteDemo.ViewModels;

namespace NoteDemo.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Note> notes;
        private readonly INoteRepository noteRepository;

        public HomeViewModel(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;

            SubscribeToSaveOccuredMessage();

            InitializeAddNoteCommand();

            LoadNotes();

        }

        private void SubscribeToSaveOccuredMessage()
        {
            MessagingCenter.Subscribe<NoteViewModel>(this, "saveoccured", n => LoadNotes());
        }

        private void InitializeAddNoteCommand()
            => AddNoteCommand = new Command( () => NavigateToNoteView(new Note()));

        private async void LoadNotes()
        {
            try
            {
                var notes = await noteRepository.GetNotes()
                ?? Enumerable.Empty<Note>();
                Notes = new ObservableCollection<Note>(notes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void NavigateToNoteView(Note value)
        {
            var noteView = Injector.Resolve<NotePage>();
            var noteViewModel = noteView.BindingContext as NoteViewModel;
            noteViewModel.Note = value;

            await Navigation.PushAsync(noteView);
        }

        public ObservableCollection<Note> Notes
        {
            get => notes;
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }

        public Note SelectedNote
        {
            get => null;
            set
            {
                if (value == null) return;
                NavigateToNoteView(value);
            }
        }


        public ICommand AddNoteCommand { get; private set; }
    }
}
