
using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ContactApp.ViewModels;

public partial class EditContactViewModel(IServiceProvider serviceProvider, IContactService contactService) : ObservableObject
{

    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;

    [ObservableProperty]
    private string _title = " EDIT CONTACT";

    [ObservableProperty]
    private Contact _contact = new();

   

    [RelayCommand]
    private void EditDetails()
    {
        

        var editDetailsViewModel = _serviceProvider.GetRequiredService<EditDetailsViewModels>();
        editDetailsViewModel.Contact = Contact;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editDetailsViewModel;
    }

    [RelayCommand]
    private void DeleteContact(Contact contact)
    {
        var result = _contactService.DeleteContactFromList(Contact.Id);

        if (result)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewContactListModels>();
        }
       
        
    }


    [RelayCommand]
    private void GoToListView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewContactListModels>();
    }
}
