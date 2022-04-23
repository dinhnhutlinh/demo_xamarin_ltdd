using NoteDemo.Database;
using NoteDemo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Injector.Initialize();

            InitializeRepository();

            InitializeMainPage();
        }

        private void InitializeMainPage()
        {
            MainPage = new NavigationPage(Injector.Resolve<HomePage>());
        }

        private static void InitializeRepository()
        {
            INoteRepository repository = Injector.Resolve<INoteRepository>();
            repository.Initialize();
          
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
