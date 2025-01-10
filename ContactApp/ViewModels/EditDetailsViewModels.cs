using Business.Dtos;
using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainApp.Models;
using Microsoft.Extensions.DependencyInjection;


namespace ContactApp.ViewModels;

public partial class EditDetailsViewModels(IServiceProvider serviceProvider, IContactService contactService) : ObservableObject
{
    
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;

    [ObservableProperty]
    private string _title = " EDIT DETAILS";

    [ObservableProperty]
    private Contact _contact = new();

   

    [RelayCommand]
    private void SaveNewDetails()
    {
        var result = _contactService.UpdateContact(Contact);

        
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewContactListModels>();
    }    
    

    [RelayCommand]
    private void GoToListView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewContactListModels>();
    }
}
