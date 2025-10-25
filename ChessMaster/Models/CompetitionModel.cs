using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Competition
{
    private string Name;
    private long ID;
    private List<long> participants = new List<long>();
    private List<long> matches = new List<long>();
    private long winner_ID;
    private Competition(string Name, int ID)
    {
        this.Name = Name;
        this.ID = Convert.ToInt64(DateTime.Now.ToString("yyyymmddhhmmss"));
    }
    private void AddPlayer(Player player)
    {
        participants.Add(player.ID);
    }
    private void CreateMatch(long ID, long player_1_ID,long player_2_ID)
    {
        Match new_match = new Match(ID,player_1_ID,player_2_ID);
        matches.Add(new_match.ID);
    }
    private void AddWinner(Player player)
    {
        winner_ID = player.ID;
    }
    private void CloseCompetition()
    {
        ///mise a jour de la compétition dans la DB
    }

    
}
