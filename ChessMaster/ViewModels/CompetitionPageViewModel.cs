using System;
using System.Collections.ObjectModel;
using System.Data;
using ChessMaster.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChessMaster.ViewModels;

public partial class CompetitionPageViewModel : ViewModelBase
{
    public ObservableCollection<CompetitionItemViewModel> CompetitionItems { get; } = new ObservableCollection<CompetitionItemViewModel>();
    [ObservableProperty]
    private long? _iD;
    [ObservableProperty]
    private string? _name;
    [ObservableProperty]
    private long? _winner;

    [RelayCommand]
    private void Search()
    {
        CompetitionItems.Clear();
        DataTable result = Connexion.FindCompetition(ID, Name);
        foreach (DataRow row in result.Rows)
        {
            CompetitionItems.Add(new CompetitionItemViewModel() { Name = row["Nom"].ToString(), ID = Convert.ToInt64(row["ID"]), Winner = Convert.ToInt64(row["Winner_ID"]) });

        }

    }







}