
using System;
using System.Security.Authentication.ExtendedProtection;
using Avalonia.Controls;

public class Person
{
    private long id_person;
    private string first_name;
    private string last_name;
    private DateOnly born_date;

    public Person(string first_name, string last_name, DateOnly born_date)
    {
        this.id_person = Convert.ToInt64(DateTime.Now.ToString("yyyymmddhhmmss"));
        this.first_name = first_name;
        this.last_name = last_name;
        this.born_date = born_date;
    }

    public long Id_person
    {
        get { return id_person; }
    }

    public string First_name
    {
        get { return first_name; }
        set { first_name = value; }
    }

        public string Last_name
    {
        get { return last_name; }
        set { last_name = value; }
    }

        public DateOnly Born_date
    {
        get { return born_date; }
        set { born_date = value; }
    }

    public override string ToString()
    {
        return string.Format("Id : {0}, Firstname : {1}, Lastname : {2}, Born date : {3}", id_person, first_name, last_name, born_date);
    }

}