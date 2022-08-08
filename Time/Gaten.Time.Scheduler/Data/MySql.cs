using Gaten.Net.Network.MySql;

namespace Gaten.Time.Scheduler.Data
{
    internal class MySql
    {
        public static MySqlManager Manager { get; set; } = new();
    }
}
