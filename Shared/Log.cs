using System.Data;
using System.Text;

namespace Shared;

public static class Log
{
    public const string TypeLog = "Log";
    public const string TypeNotice = "Notice";
    public const string TypeDebug = "Debug";
    public const string TypeWarning = "Warning";
    public const string TypeError = "Error";
    public const string TypeCritical = "Critical";

    public static readonly bool Enabled;
    public static readonly string LogPath;
    private static readonly FileStream? LogStream;

    static Log()
    {
        var config = Settings.Get<Dictionary<string, object>>("log");

        Enabled = (bool) config["enabled"];
        LogPath = ((string) config["path"]).Trim();

        if (string.IsNullOrWhiteSpace(LogPath))
        {
            Enabled = false;
        }

        if (!Enabled) return;

        var logDirectory = Path.GetDirectoryName(LogPath);

        if (!string.IsNullOrWhiteSpace(logDirectory) && !Directory.Exists(logDirectory))
            Directory.CreateDirectory(logDirectory);

        LogStream = new FileStream(LogPath, FileMode.Append);
    }

    public static async void Write(string message, string type = TypeLog)
    {
        if (!Enabled || LogStream is null) return;

        var log = $"{DateTimeSync.Now} [{type}] {message}{Environment.NewLine}";

        await LogStream.WriteAsync(Encoding.UTF8.GetBytes(log));
        await LogStream.FlushAsync();
    }
}