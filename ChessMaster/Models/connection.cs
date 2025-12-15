using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using ExCSS;
using Svg.Model.Drawables.Elements;


public static class Connexion
{
    static string dbPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\ChessMaster\database.db"));
    private static readonly string key = $@"Data Source={dbPath}";
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


    public static DataTable FindCompetition(long? ID, string? name, bool Winner_ID)
    {
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "Select * from Competition where 1=1";

            if (ID.HasValue)
            {
                query += " and ID=@ID";
                cmd.Parameters.AddWithValue("@ID", ID.ToString());
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                query += " and Nom=@name";
                cmd.Parameters.AddWithValue("@name", name);
            }
            if (Winner_ID == true)
            {
                query += " and Winner_ID IS NULL";
            }

            cmd.CommandText = query;

            conn.Open();
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            var result = new DataTable();
            result.Load(reader);
            return result;
        }
    }

    public static DataTable FindPlayer(long? ID, string? Nom, string? Prenom)
    {
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "Select * from Personne where 1=1";

            if (ID.HasValue)
            {
                query += " and ID=@ID";
                cmd.Parameters.AddWithValue("@ID", ID.ToString());
            }
            if (!string.IsNullOrWhiteSpace(Nom))
            {
                query += " and Nom=@nom";
                cmd.Parameters.AddWithValue("@nom", Nom);
            }
            if (!string.IsNullOrWhiteSpace(Prenom))
            {
                query += " and Prenom=@prenom";
                cmd.Parameters.AddWithValue("@prenom", Prenom);
            }

            cmd.CommandText = query;

            conn.Open();
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            var result = new DataTable();
            result.Load(reader);
            return result;
        }
    }

    public static void AddPlayer(long? ID, string? Nom, string? Prenom, int? Age, int? Elo, bool IsPlayer, bool IsAdmin)
    {
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "Insert into Personne (ID, Nom, Prenom, Age, Elo, IsPlayer, IsAdmin) values (@ID, @Nom, @Prenom, @Age, @Elo, @IsPlayer, @IsAdmin)";

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Nom", Nom);
            cmd.Parameters.AddWithValue("@Prenom", Prenom);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Elo", Elo);
            cmd.Parameters.AddWithValue("@IsPlayer", IsPlayer);
            cmd.Parameters.AddWithValue("@IsAdmin", IsAdmin);

            cmd.CommandText = query;

            conn.Open();
            var rowInserted = cmd.ExecuteNonQuery();
        }
    }
    public static void EditPlayer(long? ID, string? Nom, string? Prenom, int? Age, int? Elo, bool IsPlayer, bool IsAdmin)
    {
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "Update Personne set Nom = @Nom, Prenom = @Prenom, Age = @Age, Elo = @Elo, IsPlayer = @IsPlayer, IsAdmin = @IsAdmin where ID = @ID";

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Nom", Nom);
            cmd.Parameters.AddWithValue("@Prenom", Prenom);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Elo", Elo);
            cmd.Parameters.AddWithValue("@IsPlayer", IsPlayer);
            cmd.Parameters.AddWithValue("@IsAdmin", IsAdmin);

            cmd.CommandText = query;

            conn.Open();
            var rowInserted = cmd.ExecuteNonQuery();
        }
    }
    public static DataTable FindCompetitionPlayers(long competitionID)
    {
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "Select Player_1,Player_2 from Match where Competition_ID = @competitionID";
            cmd.Parameters.AddWithValue("@competitionID", competitionID);
            cmd.CommandText = query;

            conn.Open();
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            var result = new DataTable();
            result.Load(reader);
            return result;

        }
    }
    public static DataTable FindCompetitionMatches(long competitionID)
    {
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "Select * from Match where Competition_ID = @competitionID";
            cmd.Parameters.AddWithValue("@competitionID", competitionID);
            cmd.CommandText = query;

            conn.Open();
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            var result = new DataTable();
            result.Load(reader);
            return result;

        }
    }

    public static DataTable ClassementPlayer(int? AgeMin, int? AgeMax)
    {
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "SELECT * FROM Personne WHERE 1=1";

            if (AgeMin.HasValue)
            {
                query += " and Age >= @AgeMin";
                cmd.Parameters.AddWithValue("@AgeMin", AgeMin);
            }
            if (AgeMax.HasValue)
            {
                query += " and Age <= @AgeMax";
                cmd.Parameters.AddWithValue("@AgeMax", AgeMax);
            }

            query += " ORDER BY Elo DESC";


            cmd.CommandText = query;

            conn.Open();
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            var result = new DataTable();
            result.Load(reader);
            return result;
        }
    }
    public static void AddMatch(long? ID, long? Player_1, long? Player_2, long? Competition_ID)
    {
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "Insert into Match (ID, Player_1, Player_2, Competition_ID) values (@ID, @Player_1, @Player_2, @Competition_ID)";

            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Player_1", Player_1);
            cmd.Parameters.AddWithValue("@Player_2", Player_2);
            cmd.Parameters.AddWithValue("@Competition_ID", Competition_ID);

            cmd.CommandText = query;

            conn.Open();
            var rowInserted = cmd.ExecuteNonQuery();
        }
    }

    public static void EditMatch(long? ID, string? Coups, long? Winner_ID)
    {
        Console.WriteLine("hello");
        using (var conn = connection())
        {
            var cmd = new SQLiteCommand(conn);
            string query = "Update Match set ";

            query += "Coups = @Coups ";
            cmd.Parameters.AddWithValue("@Coups", Coups);

            if (Winner_ID.HasValue)
            {
                query += ",Winner_ID = @Winner_ID ";
                cmd.Parameters.AddWithValue("@Winner_ID", Winner_ID);
            }

            query += "where ID = @ID";
            cmd.Parameters.AddWithValue("@ID", ID);

            cmd.CommandText = query;

            conn.Open();
            var rowInserted = cmd.ExecuteNonQuery();
        }
    }
}