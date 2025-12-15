using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;
using CommunityToolkit.Mvvm.Input;
using System.Text.RegularExpressions;
using System;

namespace ChessMaster.ViewModels;

public partial class CompetitionMatchItemViewModel : CompetitionPageViewModel
{
    [ObservableProperty]
    private string? _depard;
    [ObservableProperty]
    private string? _arrive;
    public CompetitionMatchItemViewModel() { }
    public CompetitionMatchItemViewModel(CompetitionMatchItem item)
    {
        Match_ID = item.ID;
        Match_Player_1 = item.Player_1;
        Match_Player_2 = item.Player_2;
        Match_Competition_ID = item.Competition_ID;
        Match_Coups = item.Coups;
        Match_Winner_ID = item.Winner_ID;
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

    public void AddCoups(long? MatchPlayer)
    {
        if (Depard != null && Arrive != null)
        {
            if (Match_Coups != null)
            {
                Match_Coups = Match_Coups + '\n' + MatchPlayer.ToString() + " joue " + Depard + " -> " + Arrive;
                Console.WriteLine(Match_Coups);
            }
            else
            {
                Match_Coups = MatchPlayer.ToString() + " joue " + Depard + " -> " + Arrive;
                Console.WriteLine(Match_Coups);
            }
            Depard = null;
            Arrive = null;
        }
    }
}