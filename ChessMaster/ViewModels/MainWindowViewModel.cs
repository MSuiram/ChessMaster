using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChessMaster.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    [ObservableProperty]
    private bool _sideMenuExpanded = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(PlayerPageIsActive))]
    private ViewModelBase _currentPage;

    public bool HomePageIsActive => CurrentPage == _homePage;
    public bool PlayerPageIsActive => CurrentPage == _playerPage; 

    private readonly HomePageViewModel _homePage = new ();
    private readonly PlayerPageViewModel _playerPage = new ();  

    public MainWindowViewModel()
    {
       CurrentPage = _homePage; 
    }

    [RelayCommand]
    private void SideMenuResize()
    {
        SideMenuExpanded =! SideMenuExpanded;
    }

    [RelayCommand]
    private void GoToHome() => CurrentPage = _homePage;

    [RelayCommand]
    private void GoToPlayer() => CurrentPage = _playerPage;
    
}
