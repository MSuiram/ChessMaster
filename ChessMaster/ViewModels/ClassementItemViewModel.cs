using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using ChessMaster.Models;
using Avalonia.Controls;
using System.Drawing;
using CommunityToolkit.Mvvm.Input;
using System.Security.Cryptography;

namespace ChessMaster.ViewModels;

public partial class ClassementItemViewModel : ClassementPageViewModel
{
    public ClassementItemViewModel()
    {
    }

    public ClassementItemViewModel(ClassementItem item)
    {
        Id = item.Id;
        LastName = item.LastName;
        FirstName = item.FirstName;
        Elo = item.Elo;
        Age = item.Age;
    }
}