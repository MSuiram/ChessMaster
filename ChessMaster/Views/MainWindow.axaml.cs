using Avalonia.Controls;
using Avalonia.Input;
using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace ChessMaster.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(WeakReferenceMessenger.Default);
    }

    private void Image_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.ClickCount != 2)
            return;

        (DataContext as MainWindowViewModel)?.SideMenuResizeCommand?.Execute(null);
    }
}