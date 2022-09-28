using Gaten.Net.Extensions;

namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            string test = " a, b_+ e; c_- d_+e f gh";

            var a1 = test.SplitKeep(new string[] { "_-", "_+" });
        }

    }
}
