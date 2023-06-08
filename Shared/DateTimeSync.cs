namespace Shared;

public static class DateTimeSync
{
    public static TimeSpan TimeDifference { get; private set; } = TimeSpan.Zero;
    public static DateTime UtcNow => DateTime.UtcNow.Add(TimeDifference);
    public static DateTime Now => UtcNow.ToLocalTime();

    static DateTimeSync()
    {
        UpdateTimeSpan();
    }

    public static void UpdateTimeSpan()
    {
        try
        {
            TimeDifference = Ntp.GetNetworkTimeUtc() - DateTime.UtcNow;
        }
        catch
        {
            Log.Write("Can't sync time through NTP", Log.TypeError);
        }
    }
}