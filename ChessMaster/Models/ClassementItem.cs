namespace ChessMaster.Models;

using CommunityToolkit.Mvvm.ComponentModel;

public class ClassementItem
{
    public string? LastName;
    public string? FirstName;
    public long? Id;
    public int? Elo;
    public int? Age;

    public ClassementItem() { }

    public ClassementItem(long Id, string LastName, string FirstName, int Elo, int Age)
    {
        this.Id = Id;
        this.LastName = LastName;
        this.FirstName = FirstName;
        this.Elo = Elo;
        this.Age = Age;
    }
}