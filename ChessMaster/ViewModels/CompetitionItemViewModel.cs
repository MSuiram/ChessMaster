
using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;

namespace ChessMaster.ViewModels;

public partial class CompetitionItemViewModel : CompetitionPageViewModel
{

    public CompetitionItemViewModel()
    {
    }

    public CompetitionItemViewModel(CompetitionItem item)
    {
        ID = item.ID;
        Name = item.Name;
        Winner = item.winner_ID;
    }

}