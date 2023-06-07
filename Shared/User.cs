using System.Data;
using System.Text;
using Newtonsoft.Json;

namespace Shared;

public class User : ICloneable, IEquatable<User>
{
    public string Id;
    public string Login = string.Empty;
    public string PasswordHash = string.Empty;
    public Dictionary<string, object> Metadata = new();
    public bool IsAdmin = false;
    public bool IsBanned = false;
    public bool IsActive = false;
    public DateTime BannedAt;
    public DateTime BanExpiration;
    public DateTime CreatedAt = DateTime.Now;

    public User()
    {
        Id = Guid.NewGuid().ToString();
    }

    public User(string login, string password) : this()
    {
        Login = login;
        PasswordHash = Hash.Make(password, login);
    }

    private string GetUserDirectoryPath()
    {
        return $"Users/{Id}";
    }

    private string GetUserFilePath()
    {
        return $"{GetUserDirectoryPath()}/user.json";
    }

    public void Save(bool force = false)
    {
        var userDirectoryPath = GetUserDirectoryPath();
        var userFilePath = GetUserFilePath();

        if (!Directory.Exists(userDirectoryPath)) Directory.CreateDirectory(userDirectoryPath);

        if (!File.Exists(userFilePath) || force) File.WriteAllText(userFilePath, ToJson());
    }

    public static User Load(string path)
    {
        return FromJson(File.ReadAllText(path));
    }

    public void Remove()
    {
        var userDirectoryPath = GetUserDirectoryPath();

        if (Directory.Exists(userDirectoryPath))
            Directory.Delete(userDirectoryPath, true);
    }

    public static User FromJson(string json)
    {
        return JsonConvert.DeserializeObject<User>(json) ?? throw new NoNullAllowedException();
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public bool Equals(User? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return ToJson() == other.ToJson();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((User)obj);
    }

    public override int GetHashCode()
    {
        return ToJson().GetHashCode();
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public override string ToString()
    {
        var tags = new List<string>();

        if (IsAdmin) tags.Add("#admin");

        tags.Add(IsActive ? "#active" : "#inactive");

        if (IsBanned) tags.Add("#banned");

        return $"{Login} {string.Join(" ", tags)}";
    }
}