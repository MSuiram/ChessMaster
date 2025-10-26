using System;
using System.Data;
using System.Data.SQLite;
using System.IO.Pipelines;
using Avalonia.Automation.Peers;
using Avalonia.Controls;
using Microsoft.Data.Sqlite;
using Tmds.DBus.Protocol;

public static class Connexion
{
    private static readonly string key = @"Data Source=C:\Users\STUDENT\Documents\Prograaaaa\C#\ChessMastaaaa\ChessMaster\ChessMaster\database.db";
    /// <summary>
    /// Connexion a la datatbase 
    /// </summary>
    /// <returns>Retourne un objet de type SQLiteConnection</returns>
    public static SQLiteConnection connection()
    {
        return new SQLiteConnection(key);
    }
    /// <summary>
    /// exécute une commmande SQL non_query!
    /// </summary>
    /// <param name="query">string représentant la commande SQL a exécuter! Attention que pour les Query type!</param>
    public static void ExecuteNonQuery(string query)
    {
        using (var conn = connection())
        {
            conn.Open();
            var cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
    }
    /// <summary>
    /// retourne une Table avec la data demandée par la query
    /// </summary>
    /// <param name="query">string représentant la commade SQL a exécuter! Attention que pour les Query type!</param>
    /// <returns>retourne un objet de type DataTable</returns>
    public static DataTable ExecuteQuery(string query)
    {
        using (var conn = connection())
        {
            conn.Open();
            var cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();
            var result = new DataTable();
            result.Load(reader);
            return result;
        }
    }
}