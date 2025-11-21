using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ChessMaster.ViewModels;

public partial class PlayerPageViewModel : ViewModelBase
{

    [ObservableProperty]
    private string? _lastname;
    [ObservableProperty]

    private string? _firstname;
    [ObservableProperty]

    private string? _id;

    [ObservableProperty]
    private string? _test = "e";

    [RelayCommand]
    private void GetName() => Test = Lastname;

}