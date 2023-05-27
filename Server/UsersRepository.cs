namespace Server;

public static class UsersRepository
{
    public static UsersCollection RegisteredUsers { get; set; } = new UsersCollection();
    public static UsersCollection OnlineUsers { get; set; } = new UsersCollection();
}