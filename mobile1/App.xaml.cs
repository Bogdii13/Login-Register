namespace mobile1;
using mobile1.Database;
using mobile1.Views;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new LoginPage();
    }

    static LoginDatabase database;
    public static LoginDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new LoginDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLLiteSample.db"));
            }
            return database;
        }
    }
}
