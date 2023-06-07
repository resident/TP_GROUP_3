using Collections;
using Shared;

namespace Server;

public static class UsersRepository
{
    public static readonly UsersCollection RegisteredUsers = new();
    public static readonly UsersCollection OnlineUsers = new();

    static UsersRepository()
    {
        const string usersDirectoryPath = "Users";

        if (Directory.Exists(usersDirectoryPath))
            foreach (var directory in Directory.GetDirectories(usersDirectoryPath))
                RegisteredUsers.Add(User.Load($"{directory}/user.json"));
        else
        {
            // Add default admin account
            var adminCredentials = Settings.GetNullable<Dictionary<string, string>>("default_admin_credentials") ?? new();
            var admin = new User(adminCredentials["login"], adminCredentials["password"])
            {
                IsAdmin = true,
                IsActive = true
            };

            admin.Save();

            RegisteredUsers.Add(admin);
        }
    }
}