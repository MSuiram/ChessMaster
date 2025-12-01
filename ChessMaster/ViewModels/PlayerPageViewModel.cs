using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ChessMaster.ViewModels;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using System.Data;


namespace ChessMaster.ViewModels;

public partial class PlayerPageViewModel : ViewModelBase
{
    public ObservableCollection<PlayerItemViewModel> PlayerItems { get; } = new ObservableCollection<PlayerItemViewModel>();

    [ObservableProperty]
    private string? _lastName;

    [ObservableProperty]
    private string? _firstName;

    [ObservableProperty]
    private long? _id;

    [ObservableProperty]
    private int? _age;

    [ObservableProperty]
    private int? _elo;

    [RelayCommand]
    private void GetName()
    {
        PlayerItems.Add(new PlayerItemViewModel() { LastName = LastName, FirstName = FirstName, Id = Id });
        Console.WriteLine("PalyerItems Counter : {0}", PlayerItems.Count);

        LastName = null;
        FirstName = null;
        Id = null;
    }

    [RelayCommand]
    private void Search()
    {
        PlayerItems.Clear();
        DataTable result = Connexion.FindPlayer(Id, LastName, FirstName);
        foreach (DataRow row in result.Rows)
        {
            PlayerItems.Add(new PlayerItemViewModel() { LastName = row["Nom"].ToString(), Id = Convert.ToInt64(row["ID"]), FirstName = row["Prenom"].ToString(), Elo = Convert.ToInt32(row["Elo"]), Age = Convert.ToInt32(row["Age"]) });

        }
    }

    [RelayCommand]
    private void RemoveItem(PlayerItemViewModel item)
    {
        // Remove the given item from the list
        PlayerItems.Remove(item);
        Console.WriteLine(item.FirstName);

        LastName = item.LastName;
        FirstName = item.FirstName;
        Id = item.Id;
        Age = item.Age;
        Elo = item.Elo;
    }
}