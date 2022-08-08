namespace Gaten.Game.NGDG2.Util.Environment
{
    public class PathUtil
    {
        public static string LocalPath => System.Environment.CurrentDirectory;
        public static string AccountPath => LocalPath + @"\Resource\Account\";
        public static string NFDPath => LocalPath + @"\Resource\NFD\";
    }
}
