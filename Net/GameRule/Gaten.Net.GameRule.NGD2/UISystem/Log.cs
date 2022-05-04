namespace Gaten.Net.GameRule.NGD2.UISystem
{
    public class Log
    {
        public DateTime Time { get; set; }
        public string Text { get; set; }

        public Log(string text)
        {
            Time = DateTime.Now;
            Text = text;
        }
    }
}
