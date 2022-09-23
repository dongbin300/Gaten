namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            string test = " \t BBBBBBB  \n\t\r";

            var a1 = test.Trim();
            var a2 = test.TrimEnd();
            var a3 = test.TrimStart();
        }

    }
}
