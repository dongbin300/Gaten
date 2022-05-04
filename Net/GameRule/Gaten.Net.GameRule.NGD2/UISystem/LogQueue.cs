namespace Gaten.Net.GameRule.NGD2.UISystem
{
    public class LogQueue
    {
        static Queue<Log> Logs = new Queue<Log>();

        public static void Set(string text)
        {
            Logs.Enqueue(new Log(text));
        }

        public static bool Have()
        {
            return Logs.Count > 0;
        }

        public static Log Get()
        {
            return Logs.Dequeue();
        }
    }
}
