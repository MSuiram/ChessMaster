using Avalonia.Controls;
using Avalonia.Input;
using ChessMaster.ViewModels;

namespace ChessMaster.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Image_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.ClickCount != 2)
            return;

        (DataContext as MainWindowViewModel)?.SideMenuResizeCommand?.Execute(null);
    }
}