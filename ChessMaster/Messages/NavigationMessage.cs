using CommunityToolkit.Mvvm.Messaging.Messages;
using ChessMaster.ViewModels;

namespace ChessMaster.Messages;

public class NavigationMessage : ValueChangedMessage<ViewModelBase>
{
    public NavigationMessage(ViewModelBase viewModel) : base(viewModel)
    {
    }
}