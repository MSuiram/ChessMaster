using System;
using System.Collections.Generic;

public class Competition
{
    private string Name;
    private int ID;
    private List<PlayerModel> participants = new List<PlayerModel>();
    private List<MatchModel> matches = new List<MatchModel>();
    private int winner;
    private Competition(string Name,int ID)
    {
        this.Name = Name;
        this.ID = new DateOnly();
    }
}
