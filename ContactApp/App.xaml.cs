
using System.Windows;
using Buisness.Services;
using Business.Interfaces;
using Business.Repositories;
using ContactApp.ViewModels;
using ContactApp.Views;
using MainApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContactApp;


public partial class App : Application
{
    private IHost host;

    public App()
    {
        host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IFileService>(new FileService("contacts.json"));
                services.AddSingleton<IContactRespository, ContactRepository>();
                services.AddSingleton<IContactService, ContactService>();

                services.AddTransient<ViewContactListModels>();
                services.AddTransient<AddNewContactViewModels>();
                services.AddTransient<EditContactViewModel>();
                services.AddTransient<EditDetailsViewModels>();
                services.AddSingleton<MainViewModel>();

                services.AddTransient<EditContactView>();
                services.AddTransient<EditDetailsView>();
                services.AddTransient<ViewContactList>();
                services.AddTransient<AddNewContactView>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
