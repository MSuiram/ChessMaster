using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChessMaster.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _sideMenuExpanded = true;

    [RelayCommand]
    private void SideMenuResize()
    {
        SideMenuExpanded =! SideMenuExpanded;
    }
}
