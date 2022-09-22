namespace Gaten.Net.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToStandardString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToStandardFileName(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy_MM_dd_HH_mm_ss");
        }
    }
}
