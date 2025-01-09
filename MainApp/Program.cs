using Buisness.Services;
using Business.Interfaces;
using Business.Repositories;
using MainApp.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IFileService>(new FileService("contacts.json"))
    .AddSingleton<IContactRespository, ContactRepository>()
    .AddSingleton<IContactService, ContactService>()
    .AddTransient<MenuDialogs>()
    .BuildServiceProvider();

var menuDialog = serviceProvider.GetRequiredService<MenuDialogs>();
menuDialog.MainMenu();