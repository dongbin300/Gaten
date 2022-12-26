using System.Web;

namespace Gaten.Net.Collections
{
    public class Match
    {
        private string[] Keys { get; set; }
        private Dictionary<string, object> Values { get; set; }
        private bool IsCaseSensitive;

        public Match(bool isCaseSensitive = false)
        {
            Keys = Array.Empty<string>();
            Values = new Dictionary<string, object>();
            IsCaseSensitive = isCaseSensitive;
        }

        public void SetKey(params string[] keys)
        {
            Keys = keys;
        }

        public bool SetValue(string key, object value)
        {
            if (IsCaseSensitive)
            {
                if (Keys.Contains(key))
                {
                    Values.Add(key, value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (Keys.Select(k => k.ToUpper()).Contains(key.ToUpper()))
                {
                    Values.Add(key, value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string[] GetSampleKey()
        {
            return Keys;
        }

        public string GetSerializedSampleKey()
        {
            return string.Join(',', Keys);
        }

        public string[] GetKey()
        {
            return Values.Keys.ToArray();
        }

        public string GetSerializedKey()
        {
            return string.Join(',', Values.Keys);
        }

        public object[] GetValue()
        {
            return Values.Values.ToArray();
        }

        public string GetSerializedValue()
        {
            return string.Join(',', Values.Values);
        }

        public string GetQuotedValue()
        {
            return string.Join(',', Values.Values.Select(v => $"\'{v}\'"));
        }
    }
}
