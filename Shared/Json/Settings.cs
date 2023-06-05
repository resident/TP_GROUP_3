using Newtonsoft.Json;
using Shared.Json.Converters;

namespace Shared.Json;

public static class Settings
{
    public static void SetGlobalJsonSettings()
    {
        var globalSettings = new JsonSerializerSettings();

        globalSettings.Converters.Add(new SynchronizedDateTimeConverter());

        JsonConvert.DefaultSettings = () => globalSettings;
    }
}