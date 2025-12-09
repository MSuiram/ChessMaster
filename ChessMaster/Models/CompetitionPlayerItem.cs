namespace ChessMaster.Models;

using CommunityToolkit.Mvvm.ComponentModel;

public class CompetitionPlayerItem
{
    public long? ID;
    public string? Nom;
    public string? Prenom;
    public int? Age;
    public int? Elo;
    public CompetitionPlayerItem() { }
    public CompetitionPlayerItem(long ID, string Nom, string Prenom, int age, int Elo)
    {
        this.ID = ID;
        this.Nom = Nom;
        this.Prenom = Prenom;
        this.Age = age;
        this.Elo = Elo;
    }
}