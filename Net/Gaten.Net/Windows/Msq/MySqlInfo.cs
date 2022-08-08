using Gaten.Net.IO;

namespace Gaten.Net.Windows.Msq
{
    public class MySqlInfo
    {
        public static string ServerIp { get; set; } = string.Empty;
        public static string Port { get; set; } = string.Empty;
        public static string Id { get; set; } = string.Empty;
        public static string Password { get; set; } = string.Empty;

        public static void Initialize()
        {
            try
            {
                var data = GResource.MySqlInfoText;
                ServerIp = data[0];
                Port = data[1];
                Id = data[2];
                Password = data[3];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}