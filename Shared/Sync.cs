namespace Shared;

public static class Sync
{
    static Sync()
    {
        ResetLastChangeTime();
    }

    public static DateTime GetLastChangeTime()
    {
        return Storage.Get<DateTime>("lastChangeTime");
    }

    public static void ResetLastChangeTime()
    {
        Storage.Set("lastChangeTime", DateTime.MinValue);
    }

    public static void UpdateLastChangeTime()
    {
        Storage.Set("lastChangeTime", DateTime.Now);
    }
}