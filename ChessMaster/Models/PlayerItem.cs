namespace ChessMaster.Models;

using CommunityToolkit.Mvvm.ComponentModel;

public class PlayerItem
{
    public string? LastName;
    public string? FirstName;
    public long? Id;

    public PlayerItem() { }

    public PlayerItem(long Id, string LastName, string FirstName)
    {
        this.Id = Id;
        this.LastName = LastName;
        this.FirstName = FirstName;
    }
}