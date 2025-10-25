
using System;
using System.Security.Authentication.ExtendedProtection;
using Avalonia.Controls;

public class Person
{
    private long id_player;
    private string first_name;
    private string last_name;
    private DateOnly born_date;

    public Person(string first_name, string last_name, DateOnly born_date)
    {
        this.id_player = Convert.ToInt64(DateTime.Now.ToString("yyyymmddhhmmss"));
        this.first_name = first_name;
        this.last_name = last_name;
        this.born_date = born_date;
    }

    public string first_name
    {
        get { return first_name; }
        set { first_name = value; }
    }

    public void Change_last_name(string new_name)
    {
        last_name = new_name;
    }

    public void Change_born_date(DateOnly new_born_date)
    {
        born_date = new_born_date;
    }

    public override string ToString()
    {
        return string.Format("Id : {0}, Firstname : {1}, Lastname : {2}, Born date : {3}", id_player, first_name, last_name, born_date);
    }

}