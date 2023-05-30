using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Shared;

public class UsersCollection : BindingList<KeyValuePair<User, Dictionary<string, object>>>
{
    public void AddUser(User user)
    {
        Add(new KeyValuePair<User, Dictionary<string, object>>(user, new()));
    }

    public void AddUsers(IEnumerable<User> users)
    {
        foreach (var user in users) AddUser(user);
    }

    public bool UserExists(string login)
    {
        return this.Any(pair => pair.Key.Login == login);
    }
    
    public bool UserExists(User user)
    {
        return this.Any(pair => pair.Key == user);
    }

    public bool UserExists(string login, string passwordHash)
    {
        return this.Any(pair => pair.Key.Login == login && pair.Key.PasswordHash == passwordHash);
    }

    public KeyValuePair<User, Dictionary<string, object>>? GetPair(string login)
    {
        return UserExists(login) ? this.First(pair => pair.Key.Login == login) : null;
    }

    public KeyValuePair<User, Dictionary<string, object>>? GetPair(User user)
    {
        return UserExists(user) ? this.First(pair => pair.Key == user) : null;
    }

    public KeyValuePair<User, Dictionary<string, object>>? GetPair(string login, string passwordHash)
    {
        return UserExists(login, passwordHash) ? this.FirstOrDefault(pair => pair.Key.Login == login && pair.Key.PasswordHash == passwordHash) : null;
    }

    public User? GetUser(string login)
    {
        return GetPair(login)?.Key;
    }

    public User? GetUser(User user)
    {
        return GetPair(user)?.Key;
    }

    public User? GetUser(string login, string passwordHash)
    {
        return GetPair(login, passwordHash)?.Key;
    }

    public User? GetUserByMetadata(string key, object value)
    {
        return this.Any(pair => pair.Value.ContainsKey(key) && pair.Value[key] == value) ? this.First(pair => pair.Value.ContainsKey(key) && pair.Value[key] == value).Key : null;
    }

    public void RemoveUser(string login)
    {
        this.Where(pair => pair.Key.Login == login).ToList().ForEach(i => Remove(i));
    }

    public void RemoveUser(User user)
    {
        this.Where(pair => pair.Key == user).ToList().ForEach(i => Remove(i));
    }

    public void AddUserMetadata(string login, string key, object metadata)
    {
        GetPair(login)?.Value.Add(key, metadata);
    }

    public void AddUserMetadata(User user, string key, object metadata)
    {
        GetPair(user)?.Value.Add(key, metadata);
    }

    public object? GetUserMetadata(string login, string key)
    {
        return GetPair(login)?.Value[key];
    }

    public object? GetUserMetadata(User user, string key)
    {
        return GetPair(user)?.Value[key];
    }

    public void RemoveUserMetadata(string login, string key)
    {
        GetPair(login)?.Value.Remove(key);
    }

    public void RemoveUserMetadata(User user, string key)
    {
        GetPair(user)?.Value.Remove(key);
    }
}