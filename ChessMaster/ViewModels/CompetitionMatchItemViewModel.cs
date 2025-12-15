using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;
using CommunityToolkit.Mvvm.Input;
using System.Text.RegularExpressions;
using System;
using System.Data;

namespace ChessMaster.ViewModels;

public partial class CompetitionMatchItemViewModel : CompetitionPageViewModel
{
    [ObservableProperty]
    private string? _depard;
    [ObservableProperty]
    private string? _arrive;
    [ObservableProperty]
    private bool? _winner_P1 = false;
    [ObservableProperty]
    private bool? _winner_P2 = false;

    public CompetitionMatchItemViewModel() { }
    public CompetitionMatchItemViewModel(CompetitionMatchItem item)
    {
        Match_ID = item.ID;
        Match_Player_1 = item.Player_1;
        Match_Player_2 = item.Player_2;
        Match_Competition_ID = item.Competition_ID;
        Match_Coups = item.Coups;
        Match_Winner_ID = item.Winner_ID;
        Match_No_Winner = item.No_Winner;
    }

    [RelayCommand]
    public void AddCoupsPlayer1()
    {
        AddCoups(Match_Player_1);
    }

    [RelayCommand]
    public void AddCoupsPlayer2()
    {
        AddCoups(Match_Player_2);
    }

    [RelayCommand]
    public void SaveMatch()
    {
        if (Winner_P1 == true)
        {
            Match_Winner_ID = Match_Player_1;
            Connexion.EditMatch(Match_ID, Match_Coups, Match_Player_1);
            Elo(Match_Player_1, Match_Player_2);
            Match_No_Winner = false;
        }
        else if (Winner_P2 == true)
        {
            Match_Winner_ID = Match_Player_2;
            Connexion.EditMatch(Match_ID, Match_Coups, Match_Player_2);
            Elo(Match_Player_2, Match_Player_1);
            Match_No_Winner = false;
        }
        else
        {
            Connexion.EditMatch(Match_ID, Match_Coups, null);
        }
    }

    public void AddCoups(long? MatchPlayer)
    {
        if (Depard != null && Arrive != null)
        {
            if (Match_Coups != null)
            {
                Match_Coups = Match_Coups + '\n' + MatchPlayer.ToString() + " joue " + Depard + " -> " + Arrive;
            }
            else
            {
                Match_Coups = MatchPlayer.ToString() + " joue " + Depard + " -> " + Arrive;
            }
            Depard = null;
            Arrive = null;
        }
    }

    public void Elo(long? Winner, long? Loser)
    {
        double eloWinner = 0;
        double eloLoser = 0;

        DataTable result1 = Connexion.FindEloPlayer(Winner);
        foreach (DataRow row in result1.Rows)
        {
            eloWinner = Convert.ToInt32(row["Elo"]);
        }
        DataTable result2 = Connexion.FindEloPlayer(Loser);
        foreach (DataRow row in result2.Rows)
        {
            eloLoser = Convert.ToInt32(row["Elo"]);
        }

        double probWinner = eloWinner/(eloWinner+eloLoser);
        double probLoser = eloLoser/(eloLoser+eloWinner);

        double deloWinner = 20 *(1 - probWinner);
        double deloLoser = 20 *(0 - probLoser);

        int NewEloWinner = Convert.ToInt32(eloWinner + deloWinner);
        int NewEloLoser = Convert.ToInt32(eloWinner + deloLoser);

        Connexion.EditEloPlayer(Winner, NewEloWinner);
        Connexion.EditEloPlayer(Loser, NewEloLoser);

        Console.WriteLine("New Elo : " + Winner + " -> " + NewEloWinner + " and " + Loser + " -> " + NewEloLoser);
    }
}