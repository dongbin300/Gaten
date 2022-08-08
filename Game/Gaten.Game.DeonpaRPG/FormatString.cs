namespace Gaten.Game.DeonpaRPG
{
    internal class FormatString
    {
        public static Dictionary<string, int> ParseInt(string code)
        {
            Dictionary<string, int> items = new();
            const string Number = "0123456789-";
            string type = "name";
            string name = string.Empty;
            int value;

            for (int i = 0, s = 0; i < code.Length; i++)
            {
                switch (type)
                {
                    case "name":
                        if (Number.Contains(code[i]))
                        {
                            name = code[s..i];
                            type = "value";
                            s = i;
                        }
                        if (i == code.Length - 1)
                        {
                            value = int.Parse(code.Substring(s, i - s + 1));
                            items.Add(name, value);
                        }
                        break;
                    case "value":
                        if (i == code.Length - 1)
                        {
                            value = int.Parse(code.Substring(s, i - s + 1));
                            items.Add(name, value);
                        }
                        if (!Number.Contains(code[i]))
                        {
                            value = int.Parse(code[s..i]);
                            items.Add(name, value);
                            type = "name";
                            s = i;
                        }
                        break;
                }
            }

            return items;
        }

        public static Dictionary<string, double> ParseDouble(string code)
        {
            Dictionary<string, double> items = new();
            const string Number = ".0123456789";
            string type = "name";
            string name = string.Empty;
            double value;

            for (int i = 0, s = 0; i < code.Length; i++)
            {
                switch (type)
                {
                    case "name":
                        if (Number.Contains(code[i]))
                        {
                            name = code[s..i];
                            type = "value";
                            s = i;
                        }
                        if (i == code.Length - 1)
                        {
                            value = double.Parse(code.Substring(s, i - s + 1));
                            items.Add(name, value);
                        }
                        break;
                    case "value":
                        if (i == code.Length - 1)
                        {
                            value = double.Parse(code.Substring(s, i - s + 1));
                            items.Add(name, value);
                        }
                        if (!Number.Contains(code[i]))
                        {
                            value = double.Parse(code[s..i]);
                            items.Add(name, value);
                            type = "name";
                            s = i;
                        }
                        break;
                }
            }

            return items;
        }

        public static void Print(Dictionary<string, int> items)
        {
            foreach (KeyValuePair<string, int> temp in items)
            {
                Console.WriteLine(temp.Key + ":" + temp.Value);
            }
        }

        public static void Print(Dictionary<string, double> items)
        {
            foreach (KeyValuePair<string, double> temp in items)
            {
                Console.WriteLine(temp.Key + ":" + temp.Value);
            }
        }
    }
}
