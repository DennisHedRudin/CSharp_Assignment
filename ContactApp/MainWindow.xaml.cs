using System.Windows;
using ContactApp.ViewModels;


namespace ContactApp;


public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}