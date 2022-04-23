using System;
using Microsoft.Extensions.DependencyInjection;
using NoteDemo.Database;
using NoteDemo.ViewModels;
using NoteDemo.Views;

namespace NoteDemo
{
    public static class Injector
    {
        private static IServiceProvider serviceProvider;

        public static void Initialize()
        {
            var services = new ServiceCollection();
            services.AddSingleton<INoteRepository, SqliteNoteRepository>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<NoteViewModel>();
            services.AddTransient<HomePage>();
            services.AddTransient<NotePage>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}