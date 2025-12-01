using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ChessMaster.ViewModels;


namespace ChessMaster.ViewModels;

public partial class PlayerPageViewModel : ViewModelBase
{
    public ObservableCollection<PlayerItemViewModel> PlayerItems { get; } = new ObservableCollection<PlayerItemViewModel>();

    [ObservableProperty]
    private string? _lastName;

    [ObservableProperty]
    private string? _firstName;

    [ObservableProperty]
    private string? _id;

    [ObservableProperty]
    private string? _test;


    [RelayCommand]
    private void GetName()
    {
        PlayerItems.Add(new PlayerItemViewModel() { LastName = LastName, FirstName = FirstName, Id = Id });
        Console.WriteLine("PalyerItems Counter : {0}", PlayerItems.Count);

        LastName = null;
        FirstName = null;
        Id = null;
    }

}