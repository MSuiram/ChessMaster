using System;

class Admin : Person
{
    private string pw;

    public Admin(string first_name, string last_name, DateOnly born_date, string pw) : base(first_name, last_name, born_date)
    {
        this.pw = pw;
    }

    public string Pw
    {
        get { return pw; }
        set { pw = value; }
    }
}