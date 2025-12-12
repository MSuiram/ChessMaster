using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using ChessMaster.Messages;

namespace ChessMaster.ViewModels;

public partial class HomePageViewModel : ViewModelBase
{
    private readonly IMessenger _messenger;

    public HomePageViewModel(IMessenger messenger)
    {
        _messenger = messenger;
    }

    [RelayCommand]
    private void GoToPlayer()
    {
        // Envoi d'un message demandant la navigation
        _messenger.Send(new NavigationMessage(new PlayerPageViewModel()));
    }

    [RelayCommand]
    private void GoToCompetition()
    {
        // Envoi d'un message demandant la navigation
        _messenger.Send(new NavigationMessage(new CompetitionPageViewModel()));
    }

    [RelayCommand]
    private void GoToClassement()
    {
        // Envoi d'un message demandant la navigation
        _messenger.Send(new NavigationMessage(new ClassementPageViewModel()));
    }
}
