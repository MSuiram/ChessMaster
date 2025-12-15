using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Runtime.Versioning;
using System.Threading;
using Avalonia.Controls;
using ChessMaster.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ChessMaster.ViewModels;

public partial class CompetitionPageViewModel : ViewModelBase
{
    public ObservableCollection<CompetitionItemViewModel> CompetitionItems { get; } = new ObservableCollection<CompetitionItemViewModel>();
    public ObservableCollection<CompetitionPlayerItemViewModel> CompetitionPlayers { get; } = new ObservableCollection<CompetitionPlayerItemViewModel>();
    public ObservableCollection<CompetitionMatchItemViewModel> CompetitionMatch { get; } = new ObservableCollection<CompetitionMatchItemViewModel>();
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
    private long? _match_ID;
    [ObservableProperty]
    private long? _match_Player_1;
    [ObservableProperty]
    private long? _match_Player_2;
    [ObservableProperty]
    private long? _match_Competition_ID;
    [ObservableProperty]
    private string? _match_Coups;
    [ObservableProperty]
    private long? _match_Winner_ID;
    [ObservableProperty]
    private long? _iD;
    [ObservableProperty]
    private string? _name;
    [ObservableProperty]
    private long? _winner;
    [ObservableProperty]
    private bool? _isCompetitionVisible = true;
    [ObservableProperty]
    private bool? _isMatchVisible = false;
    [ObservableProperty]
    private bool? _isNewMatchVisible = false;
    [ObservableProperty]
    private bool? _isPlayerVisible = false;
    [ObservableProperty]
    private long _newMatch_Player1 = 0;
    [ObservableProperty]
    private long _newMatch_Player2 = 0;
    [ObservableProperty]
    private long _newMatch_ID;
    [ObservableProperty]
    private long? _newMatch_CompetitionID;


    [RelayCommand]
    private void NewMatch(CompetitionItemViewModel item)
    {
        NewMatch_ID = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
        Connexion.AddMatch(NewMatch_ID,NewMatch_Player1,NewMatch_Player2,NewMatch_CompetitionID);
        IsNewMatchVisible = false;
        IsCompetitionVisible = true;
    }
    [RelayCommand]
    private void Search()
    {
        CompetitionItems.Clear();
        DataTable result = Connexion.FindCompetition(ID, Name, false);
        foreach (DataRow row in result.Rows)
        {
            var winner = row["Winner_ID"] == DBNull.Value ? (long?)null : Convert.ToInt64(row["Winner_ID"]);
            CompetitionItems.Add(new CompetitionItemViewModel() { Name = row["Nom"].ToString(), ID = Convert.ToInt64(row["ID"]), Winner = winner });
        }
    }
    [RelayCommand]
    private void ShowCompetitions()
    {
        IsPlayerVisible = false;
        IsMatchVisible = false;
        IsCompetitionVisible = true;
        IsNewMatchVisible = false;
    }
    [RelayCommand]
    private void ShowPlayers(CompetitionItemViewModel item)
    {
        Search();
        LoadCompetitionPlayers(item.ID);
        IsPlayerVisible = true;
        IsMatchVisible = false;
        IsCompetitionVisible = false;
        IsNewMatchVisible = false;
    }
    [RelayCommand]
    private void ShowMatches(CompetitionItemViewModel item)
    {
        FindCompetitionMatch(item.ID);
        IsPlayerVisible = false;
        IsMatchVisible = true;
        IsCompetitionVisible = false;
        IsNewMatchVisible = false;
    }
    [RelayCommand]
    private void ShowNewMatch(CompetitionItemViewModel item)
    {
        NewMatch_CompetitionID = item.ID;
        IsPlayerVisible = false;
        IsMatchVisible = false;
        IsCompetitionVisible = false;
        IsNewMatchVisible = true;
    }
    private void LoadCompetitionPlayers(long? ID)
    {
        if (ID != null)
        {
            CompetitionPlayers.Clear();
            DataTable result = Connexion.FindCompetitionPlayers((long)ID);
            foreach (DataRow row in result.Rows)
            {
                FindCompetitionPLayer(Convert.ToInt64(row["Player_1"]));
                FindCompetitionPLayer(Convert.ToInt64(row["Player_2"]));
            }

        }
    }
    private void FindCompetitionPLayer(long ID)
    {
        DataTable result = Connexion.FindPlayer(ID, null, null);
        foreach (DataRow row in result.Rows)
        {
            CompetitionPlayers.Add(new CompetitionPlayerItemViewModel() { Player_iD = Convert.ToInt64(row["ID"]), Player_nom = row["Nom"].ToString(), Player_prenom = row["Prenom"].ToString(), Player_age = Convert.ToInt32(row["Age"]), Player_elo = Convert.ToInt32(row["Elo"]) });
        }
    }
    private void FindCompetitionMatch(long? ID)
    {
        if (ID != null)
        {
            CompetitionMatch.Clear();
            DataTable result = Connexion.FindCompetitionMatches((long)ID);
            foreach (DataRow row in result.Rows)
            {
                var winner = row["Winner_ID"] == DBNull.Value ? (long?)null : Convert.ToInt64(row["Winner_ID"]);
                var coups = row["Coups"] == DBNull.Value ? null : row["Coups"].ToString();
                CompetitionMatch.Add(new CompetitionMatchItemViewModel() { Match_ID = Convert.ToInt64(row["ID"]), Match_Player_1 = Convert.ToInt64(row["Player_1"]), Match_Player_2 = Convert.ToInt64(row["Player_2"]), Match_Competition_ID = Convert.ToInt64(row["Competition_ID"]), Match_Coups = coups, Match_Winner_ID = winner });
            }
        }
    }
}
