using Newtonsoft.Json;
using Shared;

namespace Server
{
    internal class Program
    {
        static async Task Main(string[] args)
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
                }
            });

            var adminCredentials = Settings.Get<Dictionary<string, string>>("default_admin_credentials") ?? new();

            Alert.Warning($"Default admin account: {adminCredentials["login"]}:{adminCredentials["password"]}");

            Alert.Warning($"Registered users: {UsersRepository.RegisteredUsers.Count}");

            Alert.Warning($"ChatsCount: {ChatsRepository.Items.Count}");

            foreach (var chat in ChatsRepository.Items)
                Alert.Show($"ID: {chat.Id} Title: {chat.Title} Messages: {chat.Messages.Count}");

            Sync.UpdateLastChangeTime();

            RequestHandlersProvider.InitHandlers();

            var server = new TcpServer("127.0.0.1", 1234);

            await server.Start();
        }
    }
}