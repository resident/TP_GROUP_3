namespace Shared;

public static class Sync
{
    public static DateTime GetLastChangeTime()
    {
        return Storage.Get<DateTime>("lastChangeTime");
    }

    public static void UpdateLastChangeTime()
    {
        Storage.Set("lastChangeTime", DateTime.Now);
    }
}