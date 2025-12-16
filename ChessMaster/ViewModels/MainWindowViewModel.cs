using System;
using ChessMaster.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ChessMaster.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IRecipient<NavigationMessage>
{

    [ObservableProperty]
    private bool _sideMenuExpanded = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(PlayerPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ClassementPageIsActive))]
    [NotifyPropertyChangedFor(nameof(CompetitionPageIsActive))]
    private ViewModelBase _currentPage;

    public bool HomePageIsActive => CurrentPage == _homePage;
    public bool PlayerPageIsActive => CurrentPage == _playerPage;
    public bool ClassementPageIsActive => CurrentPage == _classementPage;
    public bool CompetitionPageIsActive => CurrentPage == _competitionPage;

    private readonly HomePageViewModel _homePage;
    private readonly PlayerPageViewModel _playerPage;
    private readonly ClassementPageViewModel _classementPage;
    private readonly CompetitionPageViewModel _competitionPage;
    private readonly IMessenger _messenger;

    public MainWindowViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        _messenger.Register<NavigationMessage>(this);

        _homePage = new HomePageViewModel(_messenger);
        _playerPage = new PlayerPageViewModel();
        _classementPage = new ClassementPageViewModel();
        _competitionPage = new CompetitionPageViewModel();

        CurrentPage = _homePage;
        _homePage.Search();
    }

    [RelayCommand]
    private void SideMenuResize()
    {
        SideMenuExpanded = !SideMenuExpanded;
    }

    public void Receive(NavigationMessage message)
    {
        CurrentPage = message.Value;
        Console.WriteLine(message.Value);
    }

    [RelayCommand]
    public void GoToHome()
    {
        _messenger.Send(new NavigationMessage(_homePage));
        _homePage.Search();
    }
    [RelayCommand]
    private void GoToPlayer()
    {
        _messenger.Send(new NavigationMessage(_playerPage));
    }
    [RelayCommand]
    private void GoToClassement()
    {
        _messenger.Send(new NavigationMessage(_classementPage));
    }
    [RelayCommand]
    private void GoToCompetition()
    {
        _messenger.Send(new NavigationMessage(_competitionPage));
    }

}

internal class ClassementPagePageViewModel : ClassementPageViewModel
{
}