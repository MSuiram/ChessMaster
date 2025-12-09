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

public partial class ClassementPageViewModel : ViewModelBase
{
    public ObservableCollection<ClassementItemViewModel> ClassementItems { get; } = new ObservableCollection<ClassementItemViewModel>();

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
    private void JuniorClassement()
    {
        ClassementItems.Clear();
        DataTable result = Connexion.ClassementPlayer(0, 17);
        foreach (DataRow row in result.Rows)
        {
            ClassementItems.Add(new ClassementItemViewModel() { LastName = row["Nom"].ToString(), Id = Convert.ToInt64(row["ID"]), FirstName = row["Prenom"].ToString(), Elo = Convert.ToInt32(row["Elo"]), Age = Convert.ToInt32(row["Age"]) });

        }
    }

    [RelayCommand]
    private void MajorClassement()
    {
        ClassementItems.Clear();
        DataTable result = Connexion.ClassementPlayer(18, 64);
        foreach (DataRow row in result.Rows)
        {
            ClassementItems.Add(new ClassementItemViewModel() { LastName = row["Nom"].ToString(), Id = Convert.ToInt64(row["ID"]), FirstName = row["Prenom"].ToString(), Elo = Convert.ToInt32(row["Elo"]), Age = Convert.ToInt32(row["Age"]) });

        }
    }

    [RelayCommand]
    private void SeniorClassement()
    {
        ClassementItems.Clear();
        DataTable result = Connexion.ClassementPlayer(65, 200);
        foreach (DataRow row in result.Rows)
        {
            ClassementItems.Add(new ClassementItemViewModel() { LastName = row["Nom"].ToString(), Id = Convert.ToInt64(row["ID"]), FirstName = row["Prenom"].ToString(), Elo = Convert.ToInt32(row["Elo"]), Age = Convert.ToInt32(row["Age"]) });

        }
    }
}
