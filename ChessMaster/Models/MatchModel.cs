using System.Collections.Generic;
using System;

public class Match
{
    private List<long> players = new List<long>();
    public long ID;
    private List<string> coups = new List<string>();
    private long winner_ID;
    private Match(long ID, long player_1_ID,long player_2_ID)
    {
        this.ID = Convert.ToInt64(DateTime.Now.ToString("yyyymmddhhmmss"));
        players.Add(player_1_ID);
        players.Add(player_2_ID);
    }
    public void Add_Coups(string coup)
    {
        coups.Add(coup);
    }
    public void AddWinner(long ID)
    {
        winner_ID = ID;
    }
    public void Finish()
    {
        ///recup elo des joueurs dans la db
        /// calcul de l'elo
        /// retour de l'elo dans la db
    }
}
