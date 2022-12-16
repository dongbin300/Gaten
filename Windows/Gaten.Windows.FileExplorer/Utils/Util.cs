namespace Gaten.Windows.FileExplorer.Utils
{
    public class Util
    {
        static string[] SizeString = { "B", "KB", "MB", "GB", "TB" };

        public static string AbbreviatedFileSize(long fileByteSize)
        {
            double len = fileByteSize;
            int order = 0;
            while (len >= 1024 && order < SizeString.Length - 1)
            {
                order++;
                len /= 1024;
            }

            return $"{len:0.##} {SizeString[order]}";
        }
    }
}
