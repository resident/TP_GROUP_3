using Newtonsoft.Json;
using System.Data;

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

    public static T? GetNullable<T>(string key)
    {
        var value = _settings[key] is T ? (T) _settings[key] : JsonConvert.DeserializeObject<T>(_settings[key].ToString() ?? "{}");

        return value;
    }

    public static T Get<T>(string key)
    {
        return GetNullable<T>(key) ?? throw new NoNullAllowedException();
    }

    public static void Set<T>(string key, T value)
    {
        _settings[key] = value ?? throw new NoNullAllowedException();

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