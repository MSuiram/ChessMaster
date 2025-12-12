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

    [ObservableProperty]
    private bool _searchMenu = true;

    [ObservableProperty]
    private bool _editMenu = false;

    [ObservableProperty]
    private bool _addPlayerState = false;


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
    private void Save()
    {
        if (LastName != null && FirstName != null && Age != null && Elo != null)
        {
            if (AddPlayerState == true)
            {
                Connexion.AddPlayer(Id, LastName, FirstName, Age, Elo, true, false);
                Console.WriteLine("Player {0} Added", Id);
                VarToNull();
            }
            else
            {
                Connexion.EditPlayer(Id, LastName, FirstName, Age, Elo, true, false);
                Console.WriteLine("Player {0} Edited", Id);
                VarToNull();
                Search();

            }
        }
    }

    [RelayCommand]
    private void GoToSearchMenu()
    {
        SearchMenu = true;
        EditMenu = false;
        AddPlayerState = false;

        VarToNull();
    }

    [RelayCommand]
    private void GoToEditMenu(PlayerItemViewModel item)
    {
        SearchMenu = false;
        EditMenu = true;
        AddPlayerState = false;

        LastName = item.LastName;
        FirstName = item.FirstName;
        Id = item.Id;
        Age = item.Age;
        Elo = item.Elo;
    }

    [RelayCommand]
    private void GoToAddMenu()
    {
        SearchMenu = false;
        EditMenu = true;
        AddPlayerState = true;

        VarToNull();

        Id = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
    }

    private void VarToNull()
    {
        LastName = null;
        FirstName = null;
        Id = null;
        Age = null;
        Elo = null;
    }
}