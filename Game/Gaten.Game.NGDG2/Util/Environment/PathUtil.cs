namespace Gaten.Game.NGDG2
{
    public class PathUtil
    {
        public static string LocalPath => Environment.CurrentDirectory;
        public static string AccountPath => LocalPath + @"\Resource\Account\";
        public static string NFDPath => LocalPath + @"\Resource\NFD\";
    }
}
