namespace ChessMaster.Models;

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using HarfBuzzSharp;

public class CompetitionMatchItem
{
    public long? ID;
    public long? Player_1;
    public long? Player_2;
    public long? Competition_ID;
    public string? Coups;
    public long? Winner_ID;
    public bool? No_Winner;
    public CompetitionMatchItem() { }
    public CompetitionMatchItem(long ID, long Player_1, long Player_2, long Competition_ID, string Coups, long Winner_ID, bool No_Winner)
    {
        this.ID = ID;
        this.Player_1 = Player_1;
        this.Player_2 = Player_2;
        this.Competition_ID = Competition_ID;
        this.Coups = Coups;
        this.Winner_ID = Winner_ID;
        this.No_Winner = No_Winner;
    }
}