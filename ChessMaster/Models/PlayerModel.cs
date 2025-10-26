

using System;
using Avalonia.Animation.Easings;

class Player : Person
{
    private int elo;
    
    public Player(string first_name, string last_name, DateOnly born_date, int elo) : base(first_name, last_name, born_date)
    {
        this.elo = elo;
    }

    public int Elo
    {
        get { return elo; }
        set { elo = value; }
    }
}