using System;
using Airport.Data;
using System.IO;
namespace Airport;

public partial class App : Application
{
    static FlightListDatabase database;
    public static FlightListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               FlightListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "FlightList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
