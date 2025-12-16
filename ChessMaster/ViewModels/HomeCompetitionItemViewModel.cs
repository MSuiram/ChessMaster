using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ChessMaster.ViewModels;

public partial class HomeCompetitionItemViewModel : HomePageViewModel
{


    public HomeCompetitionItemViewModel() : base(WeakReferenceMessenger.Default)
    {
    }

    public HomeCompetitionItemViewModel(HomeCompItem item) : base(WeakReferenceMessenger.Default)
    {
        Id = item.Id;
        Name = item.Name;
    }


}