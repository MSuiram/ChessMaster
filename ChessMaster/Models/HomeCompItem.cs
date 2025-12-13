namespace ChessMaster.Models;

using CommunityToolkit.Mvvm.ComponentModel;

public class HomeCompItem
{
    public string? Name;
    public long? Id;

    public HomeCompItem() { }

    public HomeCompItem(long Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }
}