using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для OrderInfo
/// </summary>
public class OrderInfo
{
    private string model;
    private string lastname;
    private string name;
    private DateTime date;
    public string problem;
    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public string Lastname
    {
        get { return lastname; }
        set { lastname = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Problem
    {
        get { return problem; }
        set { problem = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }



}
