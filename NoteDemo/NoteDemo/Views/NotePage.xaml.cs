using Xamarin.Forms;
using NoteDemo.ViewModels;

namespace NoteDemo.Views
{
    public partial class NotePage : ContentPage
    {
        public NotePage(NoteViewModel noteViewModel )
        {
            InitializeComponent();

            noteViewModel.Navigation = Navigation;
            BindingContext = noteViewModel;
        }
    }
}