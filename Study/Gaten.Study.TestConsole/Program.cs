using System.Diagnostics;

namespace Gaten.Study.TestConsole
{
    public class Program
    {
        static void Main()
        {
            try
            {
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(0);
                    var value = cpuCounter.NextValue();
                    Console.WriteLine(value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
