namespace Gaten.Net.GameRule.GITADORA
{
    public class PathComparer : IComparer<Path>
    {
        public int Compare(Path x, Path y)
        {
            return x.timing > y.timing ? 1 : x.timing < y.timing ? -1 : 0;
        }
    }
}
