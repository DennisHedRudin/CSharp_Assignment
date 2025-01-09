using Business.Dtos;
using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace ContactApp.ViewModels;

public partial class AddNewContactViewModels(IContactService contactService, IServiceProvider serviceProvider) : ObservableObject
{   
    private readonly IContactService _contactService = contactService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private ContactRegistrationForm form = new();

    [ObservableProperty]
    private string _title = " ADD NEW CONTACT";

    [RelayCommand]
    private void GoToListView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewContactListModels>();
    }

    [RelayCommand]
    private void AddContactToList()
    {
        
        var result = _contactService.CreateContact(Form);
        
        if (result)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewContactListModels>();
        }

        
    }
}
