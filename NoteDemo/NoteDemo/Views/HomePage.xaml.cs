using NoteDemo.ViewModels;
using Xamarin.Forms;

namespace NoteDemo.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomeViewModel homeViewModel)
        {
            InitializeComponent();

            homeViewModel.Navigation = Navigation;
            BindingContext = homeViewModel;

            ResetCollectionViewSelection();
        }

        private void ResetCollectionViewSelection()
        {
            NoteCollectionView.SelectionChanged += (s, e)
                => NoteCollectionView.SelectedItem = null;
        }
    }
}