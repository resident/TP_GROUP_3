using Newtonsoft.Json;

namespace Shared;

public class User
{
    public string Login = string.Empty;
    public string PasswordHash = string.Empty;
    public bool IsAdmin = false;
    public bool IsBanned = false;
    public DateTime BannedAt;
    public DateTime BanExpiration;

    public User()
    {
    }

    public User(string login, string password)
    {
        Login = login;
        PasswordHash = Hash.Make(password, login);
    }

    public static User? FromJson(string json)
    {
        return JsonConvert.DeserializeObject<User>(json);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public override string ToString()
    {
        return ToJson();
    }
}