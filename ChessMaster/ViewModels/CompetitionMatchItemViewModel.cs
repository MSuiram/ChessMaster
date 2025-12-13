using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;

namespace ChessMaster.ViewModels;

public partial class CompetitionMatchItemViewModel : CompetitionPageViewModel
{
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
}