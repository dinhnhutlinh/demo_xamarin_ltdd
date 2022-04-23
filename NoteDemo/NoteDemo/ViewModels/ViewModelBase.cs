using System;
using Xamarin.Forms;

namespace NoteDemo.ViewModels
{
    public class ViewModelBase : BindableObject
    {
        public INavigation Navigation { get; set; }
    }
}