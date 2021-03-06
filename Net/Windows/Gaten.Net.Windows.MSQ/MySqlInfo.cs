using Gaten.Net.Data.IO;

namespace Gaten.Net.Windows.MSQ
{
    public class MySqlInfo
    {
        public static string ServerIp { get; set; }
        public static string Port { get; set; }
        public static string Id { get; set; }
        public static string Password { get; set; }

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