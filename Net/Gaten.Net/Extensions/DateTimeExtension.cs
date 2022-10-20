namespace Gaten.Net.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToStandardString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// yyyy_MM_dd_HH_mm_ss
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToStandardFileName(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy_MM_dd_HH_mm_ss");
        }

        /// <summary>
        /// yyyyMMddHHmmss
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToSimpleFileName(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMddHHmmss");
        }
    }
}
