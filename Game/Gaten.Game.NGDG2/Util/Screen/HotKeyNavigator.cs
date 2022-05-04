using System.Text;

namespace Gaten.Game.NGDG2
{
    public class HotKeyNavigator
    {
        public Dictionary<string, string> HotKeys;

        public HotKeyNavigator()
        {
            HotKeys = new Dictionary<string, string>();
        }

        public HotKeyNavigator AddHotKey(string key, string description)
        {
            HotKeys.Add(key, description);

            return this;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("");

            foreach(KeyValuePair<string, string> pair in HotKeys)
            {
                str.Append($"[{pair.Key}] {pair.Value} ");
            }

            return str.ToString();
        }
    }
}
