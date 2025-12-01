
using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;

namespace ChessMaster.ViewModels;

public partial class PlayerItemViewModel : PlayerPageViewModel
{
    public PlayerItemViewModel()
    {
    }

    public PlayerItemViewModel(PlayerItem item)
    {
        LastName = item.LastName;
        FirstName = item.FirstName;
        Id = item.Id;
    }

    public PlayerItem GetPlayerItem()
    {
        return new PlayerItem()
        {
            LastName = this.LastName,
            FirstName = this.FirstName,
            Id = this.Id,
        };
    }
}

public class PlayerItem
{
    public string? LastName { get; internal set; }
    public string? FirstName { get; internal set; }
    public string? Id { get; internal set; }
}

