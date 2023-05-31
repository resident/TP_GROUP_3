using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server
{
    internal static class Settings
    {
        private static Dictionary<string, object> _settings = new()
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
        };

        static Settings()
        {
            if (File.Exists("settings.json"))
                Load();
            else
                Save();
        }

        public static void Load()
        {
            _settings = FromJson(File.ReadAllText("settings.json")) ?? new Dictionary<string, object>();
        }
        
        public static void Save()
        {
            File.WriteAllText("settings.json", ToJson());
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
}
