using System;
using System.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChessMaster.ViewModels;

public partial class CompetitionPageViewModel : ViewModelBase
{
    [ObservableProperty]
    private long? _iD;
    [ObservableProperty]
    private string? _name;
    [ObservableProperty]
    private long? _player;

    [RelayCommand]
    private void Search()
    {
        DataTable result = Connexion.FindCompetition(ID, Name);
        foreach (DataRow row in result.Rows)
        {
            foreach (DataColumn col in result.Columns)
            {
                Console.Write($"{col.ColumnName}: {row[col]}  ");
            }
            Console.WriteLine();
        }

    }







}