using ChessMaster.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;

namespace ChessMaster.Messages;

public class WindowPlayerMessage : AsyncRequestMessage<WindowPlayerViewModel?>;