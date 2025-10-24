using System.Collections.Generic;
using Avalonia.Controls;

public class Match
{
    private List<Player> players = new List<Player>();
    public long ID;
    private List<string> coups = new List<string>();
    private long winner_ID;
}