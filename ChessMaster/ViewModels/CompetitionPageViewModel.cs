using System;
using System.Collections.ObjectModel;
using System.Data;
using Avalonia.Controls;
using ChessMaster.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ChessMaster.ViewModels;

public partial class CompetitionPageViewModel : ViewModelBase
{
    public ObservableCollection<CompetitionItemViewModel> CompetitionItems { get; } = new ObservableCollection<CompetitionItemViewModel>();
    public ObservableCollection<CompetitionPlayerItemViewModel> CompetitionPlayers { get; } = new ObservableCollection<CompetitionPlayerItemViewModel>();
    [ObservableProperty]
    private long? _player_iD;
    [ObservableProperty]
    private string? _player_nom;
    [ObservableProperty]
    private string? _player_prenom;
    [ObservableProperty]
    private int? _player_age;
    [ObservableProperty]
    private int? _player_elo;

    [ObservableProperty]
    private long? _iD;
    [ObservableProperty]
    private string? _name;
    [ObservableProperty]
    private long? _winner;
    [ObservableProperty]
    private bool? _isCompetitionVisible = true;
    [ObservableProperty]
    private bool _isPlayerVisible = false;

    [RelayCommand]
    private void Search()
    {
        CompetitionItems.Clear();
        DataTable result = Connexion.FindCompetition(ID, Name);
        foreach (DataRow row in result.Rows)
        {
            CompetitionItems.Add(new CompetitionItemViewModel() { Name = row["Nom"].ToString(), ID = Convert.ToInt64(row["ID"]), Winner = Convert.ToInt64(row["Winner_ID"]) });
        }
    }
    [RelayCommand]
    private void Return()
    {
        IsPlayerVisible = !IsPlayerVisible;
        IsCompetitionVisible = !IsCompetitionVisible;
    }
    [RelayCommand]
    private void ShowCompetition(CompetitionItemViewModel item)
    {
        Search();
        LoadCompetitionPlayers(item.ID);
        IsPlayerVisible = !IsPlayerVisible;
        IsCompetitionVisible = !IsCompetitionVisible;
    }
    private void LoadCompetitionPlayers(long? ID)
    {
        if (ID != null)
        {
            CompetitionPlayers.Clear();
            DataTable result = Connexion.FindCompetitionPlayers((long)ID);
            foreach (DataRow row in result.Rows)
            {
                AddPlayerToCompetition(Convert.ToInt64(row["Player_1"]));
                AddPlayerToCompetition(Convert.ToInt64(row["Player_2"]));
            }

        }
    }
    private void AddPlayerToCompetition(long ID)
    {
        DataTable result = Connexion.FindPlayer(ID, null, null);
        foreach (DataRow row in result.Rows)
        {
            Console.WriteLine("Adding player to competition viewmodel");
            Console.WriteLine(row["Nom"].ToString());
            CompetitionPlayers.Add(new CompetitionPlayerItemViewModel() { Player_iD = Convert.ToInt64(row["ID"]), Player_nom = row["Nom"].ToString(), Player_prenom = row["Prenom"].ToString(), Player_age = Convert.ToInt32(row["Age"]), Player_elo = Convert.ToInt32(row["Elo"]) });
        }
    }
}
