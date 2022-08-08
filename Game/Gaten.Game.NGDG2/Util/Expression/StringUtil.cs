namespace Gaten.Game.NGDG2.Util.Expression
{
    public class StringUtil
    {
        public static bool IsEmpty(string str, bool includeSpace = true)
        {
            return includeSpace ? str.All(char.IsWhiteSpace) : str == string.Empty;
        }
    }
}
