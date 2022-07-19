using Gaten.Net.Extension;
using Gaten.Net.Data;
using Gaten.Net.Data.Math;
using Gaten.Net.Image;
using System.Drawing;



namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            int[,] a = new int[4, 3];

            a[0, 0] = 1;
            a[0, 1] = 2;
            a[0, 2] = 3;
            a[1, 0] = 4;
            a[1, 1] = 5;
            a[1, 2] = 6;
            a[2, 0] = 7;
            a[2, 1] = 8;
            a[2, 2] = 9;
            a[3, 0] = 10;
            a[3, 1] = 11;
            a[3, 2] = 12;

            var b = a.Split(1, 1, 3, 2);
            Console.WriteLine(b);
        }
    }
}
