namespace WinFormsApp1;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Console.WriteLine("ozaiiapp is started successfully");
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}