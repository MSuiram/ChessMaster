
using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;

namespace ChessMaster.ViewModels;

public partial class PlayerItemViewModel : PlayerPageViewModel
{
    public PlayerItemViewModel()
    {
    }

    public PlayerItemViewModel(PlayerItem item)
    {
        LastName = item.LastName;
    }

    [ObservableProperty]
    private string? _lastname;

    public PlayerItem GetPlayerItem()
    {
        return new PlayerItem()
        {
            LastName = this.Lastname,
        };
    }
}

public class PlayerItem
{
    public string? LastName { get; internal set; }
}