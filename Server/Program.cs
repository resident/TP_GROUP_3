using Newtonsoft.Json;
using System.Timers;
using Shared;

namespace Server
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            Shared.Json.Settings.SetGlobalJsonSettings();

            Settings.Load(new Dictionary<string, object>
            {
                {
                    "default_admin_credentials", new Dictionary<string, string>
                    {
                        {"login", "admin"},
                        {"password", "password"},
                    }
                },
                {
                    "general_chat", new Dictionary<string, string>
                    {
                        {"id", Guid.NewGuid().ToString()},
                        {"title", "General"},
                    }
                },
                {
                    "log", new Dictionary<string, object>
                    {
                        {"enabled", true},
                        {"path", "server.log"}
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

            var adminCredentials = Settings.Get<Dictionary<string, string>>("default_admin_credentials");

            Alert.Warning($"Default admin account: {adminCredentials["login"]}:{adminCredentials["password"]}");

            Alert.Warning($"Registered users: {UsersRepository.RegisteredUsers.Count}");

            Alert.Warning($"ChatsCount: {ChatsRepository.Items.Count}");

            foreach (var chat in ChatsRepository.Items)
                Alert.Show($"ID: {chat.Id} Title: {chat.Title} Messages: {chat.Messages.Count}");

            var banTimer = new System.Timers.Timer();

            banTimer.Interval = 1000;
            banTimer.Elapsed += new ElapsedEventHandler(HandleBanExpiration);
            banTimer.AutoReset = true;
            banTimer.Start();

            var dateTimeSyncTimer = new System.Timers.Timer();

            dateTimeSyncTimer.Interval = 2000;
            dateTimeSyncTimer.Elapsed += new ElapsedEventHandler(delegate {DateTimeSync.UpdateTimeSpan();});
            dateTimeSyncTimer.AutoReset = true;
            dateTimeSyncTimer.Start();

            Sync.UpdateLastChangeTime();

            var server = new TcpServer("127.0.0.1", 1234);

            await server.Start();
        }

        private static void HandleBanExpiration(object? sender, ElapsedEventArgs args)
        {
            foreach (var user in UsersRepository.RegisteredUsers)
            {
                if (!user.IsBanned || user.BanExpiration > DateTimeSync.UtcNow) continue;

                user.IsBanned = false;
                user.BanExpiration = DateTime.MinValue;
                user.BannedAt = DateTime.MinValue;

                user.Save(true);

                Sync.UpdateLastChangeTime();
            }
        }
    }
}