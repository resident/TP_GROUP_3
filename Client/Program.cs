using System.Net.Sockets;
using Shared;

namespace Client
{
    internal static class Program
    {
        private static readonly MainForm MainForm = new();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _ = new Mutex(true, "MyAppMutex", out var isNewInstance);

            if (!isNewInstance) Environment.Exit(0);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Shared.Json.Settings.SetGlobalJsonSettings();

            Settings.Load(new Dictionary<string, object>
            {
                {"server_ip_address", "127.0.0.1"},
                {"server_port", 1234},
                {
                    "log", new Dictionary<string, object>
                    {
                        {"enabled", true},
                        {"path", "client.log"}
                    }
                },
                {
                    "ntp", new Dictionary<string, object>
                    {
                        {"host", "pool.ntp.org"},
                        {"port", 123}
                    }
                }
            });

            DateTimeSync.UpdateTimeSpan();

            Application.Run(MainForm);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            switch (e.Exception)
            {
                case SocketException:
                    MainForm.Client.Close();
                    MainForm.Connected = false;
                    break;
                default:
                    Alert.Error($"{e.Exception.GetType()} - {e.Exception.Message}");
                    break;
            }
        }
    }
}