using Shared;

namespace Collections;

public class UsersCollection : Collection<User>
{
    public void AddUsers(IEnumerable<User> users)
    {
        AddItems(users);
    }

    public bool ExistsById(string id)
    {
        return Items.Any(u => u.Id == id);
    }

    public bool ExistsByLogin(string login)
    {
        return Items.Any(user => user.Login == login);
    }

    public User? GetByUser(User user)
    {
        return Items.FirstOrDefault(u => u == user);
    }

    public User? GetByLogin(string login)
    {
        return this.FirstOrDefault(user => user.Login == login);
    }

    public User? GetById(string id)
    {
        return this.FirstOrDefault(u => u.Id == id);
    }

    public User? GetUser(string login, string passwordHash)
    {
        return Items.FirstOrDefault(u => u.Login == login && u.PasswordHash == passwordHash);
    }

    public User? GetUserByMetadata(string key, object value)
    {
        return Items.FirstOrDefault(u => u.Metadata.ContainsKey(key) && u.Metadata[key] == value);
    }

    public void RemoveById(string id)
    {
        RemoveAll(u => u.Id == id);
    }
}