using System.Globalization;

namespace TestingApi;

public static class DateUtils
{
    public static DateTime GetDateTime(string dateString, string format)
    {
        return DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
    }
}