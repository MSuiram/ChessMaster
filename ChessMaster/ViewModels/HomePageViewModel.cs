using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using ChessMaster.Messages;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Data;
using System;

namespace ChessMaster.ViewModels;

public partial class HomePageViewModel : ViewModelBase
{
    public ObservableCollection<HomeCompetitionItemViewModel> HomeCompItems { get; } = new ObservableCollection<HomeCompetitionItemViewModel>();
    private readonly IMessenger _messenger;

    [ObservableProperty]
    private long? _id;

    [ObservableProperty]
    private string? _name;

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
        _messenger.Send(new NavigationMessage(new CompetitionPageViewModel()));
    }

    [RelayCommand]
    private void GoToClassement()
    {
        // Envoi d'un message demandant la navigation
        _messenger.Send(new NavigationMessage(new ClassementPageViewModel()));
    }

    public void Search()
    {
        HomeCompItems.Clear();
        DataTable result = Connexion.FindCompetition(null, null, true);
        foreach (DataRow row in result.Rows)
        {
            HomeCompItems.Add(new HomeCompetitionItemViewModel() { Name = row["Nom"].ToString(), Id = Convert.ToInt64(row["ID"]) });
        }
    }
}
