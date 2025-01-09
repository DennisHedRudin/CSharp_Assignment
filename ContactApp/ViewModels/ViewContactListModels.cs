using System.Collections.ObjectModel;
using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainApp.Models;
using Microsoft.Extensions.DependencyInjection;
namespace ContactApp.ViewModels;

public partial class ViewContactListModels : ObservableObject
{
    private readonly IContactService _contactService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private string _title = " VIEW CONTACTLIST";

    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = [];

    public ViewContactListModels(IContactService contactService, IServiceProvider serviceProvider)
    {
        _contactService = contactService;
        _contacts = new ObservableCollection<Contact>(_contactService.GetAllContacts());
        _serviceProvider = serviceProvider;
    }

    [RelayCommand]
    private void GoToAddView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddNewContactViewModels>();
    }

    [RelayCommand]

    private void GoToEditView(Contact contact)
    {
        var editContactViewModel = _serviceProvider.GetRequiredService<EditContactViewModel>();
        editContactViewModel.Contact = contact;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editContactViewModel;
    }


}