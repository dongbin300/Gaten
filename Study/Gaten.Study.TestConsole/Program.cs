using Gaten.Net.Extensions;

namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            List<string> list = new List<string>
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P"
            };

            var result = list.Substring(3, 6);
        }
    }
}
