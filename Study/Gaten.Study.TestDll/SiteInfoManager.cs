using System.IO.MemoryMappedFiles;

namespace Gaten.Study.TestDll
{
    public class SiteInfoManager : MarshalByRefObject
    {
        public static SiteInfo SiteInfo { get; set; } = new SiteInfo();

        public static void CreateServer()
        {
            //MemoryMappedFile.
        }

        public static SiteInfo GetSiteInfo()
        {
            return SiteInfo;
        }

        public static void AddSiteInfo(string key, string value)
        {
            SiteInfo.Data.Add(key, value);
        }
    }
}
