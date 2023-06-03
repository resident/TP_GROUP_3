namespace Shared;

public static class Storage
{
    private static readonly Dictionary<string, object> Items = new();

    public static T? Get<T>(string key, bool throwIfNull = true)
    {
        Items.TryGetValue(key, out var item);

        if (null == item) throw new ArgumentNullException(key);

        return (T?) item;
    }

    public static void Set(string key, object value)
    {
        Items[key] = value;
    }

    public static void Remove(string key)
    {
        Items.Remove(key);
    }
}