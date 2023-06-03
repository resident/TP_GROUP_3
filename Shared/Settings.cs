using Newtonsoft.Json;

namespace Shared;

internal static class Settings
{
    private const string SettingsFilePath = "settings.json";

    private static Dictionary<string, object> _settings = new();

    public static int Count => _settings.Count;
    
    public static bool Empty => Count == 0;

    public static void Load(Dictionary<string, object> defaults)
    {
        if (File.Exists(SettingsFilePath))
        {
            _settings = FromJson(File.ReadAllText(SettingsFilePath)) ?? new Dictionary<string, object>();
        }
        else
        {
            _settings = defaults;
            
            Save();
        }
    }
        
    public static void Save()
    {
        File.WriteAllText(SettingsFilePath, ToJson());
    }

    public static T? Get<T>(string key, bool throwIfNull = true)
    {
        var value = _settings[key] is T ? (T) _settings[key] : JsonConvert.DeserializeObject<T>(_settings[key].ToString() ?? "{}");

        if (throwIfNull && value == null) throw new ArgumentNullException(key);

        return value;
    }

    public static void Set<T>(string key, T value)
    {
        _settings[key] = value;

        Save();
    }

    public static string ToJson()
    {
        return JsonConvert.SerializeObject(_settings, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        });
    }

    public static Dictionary<string, object>? FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    }
}