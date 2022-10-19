using Gaten.Net.Extensions;

namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            string test1 = "6";
            string test2 = "4~";
            string test3 = "~3";
            string test4 = "2~3";

            var r11 = test1.Split('~', StringSplitOptions.None);
            var r12 = test1.Split('~', StringSplitOptions.RemoveEmptyEntries);
            var r21 = test2.Split('~', StringSplitOptions.None);
            var r22 = test2.Split('~', StringSplitOptions.RemoveEmptyEntries);
            var r31 = test3.Split('~', StringSplitOptions.None);
            var r32 = test3.Split('~', StringSplitOptions.RemoveEmptyEntries);
            var r41 = test4.Split('~', StringSplitOptions.None);
            var r42 = test4.Split('~', StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
