using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainApp.Models;
using Microsoft.Extensions.DependencyInjection;


namespace ContactApp.ViewModels;

public partial class EditDetailsViewModels(IServiceProvider serviceProvider) : ObservableObject
{
    
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private string _title = " EDIT DETAILS";

    [ObservableProperty]
    private Contact _contact = new();

    [RelayCommand]
    private void SaveNewDetails()
    {
        //var result = _contactService.UpdateContact();

        var editDetailsViewModel = _serviceProvider.GetRequiredService<EditDetailsViewModels>();
        editDetailsViewModel.Contact = Contact;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editDetailsViewModel;
    }

    [RelayCommand]
    private void DeleteContact()
    {
        //var result = _contactService.UpdateContact();

        var editDetailsViewModel = _serviceProvider.GetRequiredService<EditDetailsViewModels>();
        editDetailsViewModel.Contact = Contact;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editDetailsViewModel;
    }
    

    [RelayCommand]
    private void GoToListView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewContactListModels>();
    }
}
