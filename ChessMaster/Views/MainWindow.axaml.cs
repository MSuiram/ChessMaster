using Avalonia.Controls;
using Avalonia.Input;
using ChessMaster.Messages;
using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace ChessMaster.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        if (Design.IsDesignMode)
            return;

        // Whenever 'Send(new PurchaseAlbumMessage())' is called, invoke this callback on the MainWindow instance:
        WeakReferenceMessenger.Default.Register<MainWindow, WindowPlayerMessage>(this, static (w, m) =>
        {
            // Create an instance of MusicStoreWindow and set MusicStoreViewModel as its DataContext.
            var dialog = new AddPlayerWindow
            {
                DataContext = new PlayerPageViewModel()
            };
            // Show dialog window and reply with returned AlbumViewModel or null when the dialog is closed.
            m.Reply(dialog.ShowDialog<WindowPlayerViewModel?>(w));
        });
    }

    private void Image_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.ClickCount != 2)
            return;

        (DataContext as MainWindowViewModel)?.SideMenuResizeCommand?.Execute(null);
    }
}