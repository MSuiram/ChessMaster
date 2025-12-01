namespace ChessMaster.Models;

using CommunityToolkit.Mvvm.ComponentModel;

public class CompetitionItem
{
    public long? ID;
    public string? Name;
    public string? Date;
    public long? winner_ID;
    public CompetitionItem() { }
    public CompetitionItem(long ID, string Name, string Date, long winner_ID)
    {
        this.ID = ID;
        this.Name = Name;
        this.Date = Date;
        this.winner_ID = winner_ID;
    }
}