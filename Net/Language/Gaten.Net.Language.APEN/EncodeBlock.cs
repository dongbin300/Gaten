using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Language.APEN
{
    public class EncodeBlock
    {
        public static readonly char NONE_TEXT = (char)0x0000;

        public List<char> PlainCollection { get; set; }

        public List<string> ApenCollection { get; set; }

        public string ApenText => string.Join("", ApenCollection);

        public EncodeBlock()
        {
            PlainCollection = new List<char>();
            ApenCollection = new List<string>();
        }

        public void AddBlock(char plainText, string apenText)
        {
            PlainCollection.Add(plainText);
            ApenCollection.Add(apenText);
        }

        public int GetApenIndex(int index)
        {
            var collection = ApenCollection.Take(index - 1);

            if (!collection.Any())
            {
                return 0;
            }

            StringBuilder builder = new();
            builder.AppendJoin("", collection);

            return builder.Length;
        }
    }
}
