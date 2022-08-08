using Gaten.Net.Math;
using Gaten.Study.TestDll;

namespace Gaten.Study.TestConsole
{
    public class Program
    {
        public static void Main()
        {
            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine(Dummy.OfMobilePhoneNumber());
                Console.WriteLine(Dummy.OfEmailAddress());
                Console.WriteLine(Dummy.OfCode(64));
                Console.WriteLine(Dummy.OfCodeEx(128));
            }
            //SiteInfoManager.AddSiteInfo("Software Version", "43.7.44.78-a1-ssh-t18");
            //SiteInfoManager.AddSiteInfo("Reset", "ResetButton");
            //SiteInfoManager.AddSiteInfo("Export Config File", "ExportButton");
        }
    }
}
