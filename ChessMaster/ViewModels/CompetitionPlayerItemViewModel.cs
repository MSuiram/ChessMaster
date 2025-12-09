
using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;

namespace ChessMaster.ViewModels;

public partial class CompetitionPlayerItemViewModel : CompetitionPageViewModel
{

    public CompetitionPlayerItemViewModel()
    {
    }

    public CompetitionPlayerItemViewModel(CompetitionPlayerItem item)
    {
        Player_iD = item.ID;
        Player_nom = item.Nom;
        Player_prenom = item.Prenom;
        Player_age = item.Age;
        Player_elo = item.Elo;
    }

}