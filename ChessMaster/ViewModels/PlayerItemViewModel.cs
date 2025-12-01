
using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;

namespace ChessMaster.ViewModels;

public partial class PlayerItemViewModel : PlayerPageViewModel
{
    public PlayerItemViewModel()
    {
    }

    public PlayerItemViewModel(PlayerItem item)
    {
        Id = item.Id;
        LastName = item.LastName;
        FirstName = item.FirstName;
    }
}

