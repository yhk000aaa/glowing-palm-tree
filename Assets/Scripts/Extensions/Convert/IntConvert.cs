using System;

public static class IntConvert
{
    public static int toCCRandomIndex(this int i) { return i.toRandomIndex(RandomSync.CCRANDOM); }
    public static int toWDRandomIndex(this int i) { return i.toRandomIndex(RandomSync.WDRANDOM); }
    public static int toRandomIndex(this int i, int count) { return i <= 0 ? 0 : count % i; }

    public static float toRadian(this int i) { return i.toFloat().toRadian(); }
    public static float toAngle(this int i) { return i.toFloat().toAngle(); }

    public static bool isNotFound(this int i) { return i == IC.NotFound; }

    public static DateTime GetDateTime(this int timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(IC.GreenwichDateTime);  
        DateTime targetDt = dtStart.AddSeconds(timeStamp.toLong());  
        return targetDt;
    } 
}

public static class IC
{
    public static readonly int NotFound = -1;
    public static readonly int MinusTwo = -2;

    public static readonly string Type = "int";

    public const int NO = 0;
    public const int YES = 1;

    public static DateTime GreenwichDateTime = new DateTime(1970, 1, 1);

    public const int OneSecond = 1;
    public const int OneMinute = 60;
    public const int OneHour = 3600;
    public const int OneDay = 86400;
    public const int OneWeek = 604800;
    public const int OneYear = OneDay * 365;
}
