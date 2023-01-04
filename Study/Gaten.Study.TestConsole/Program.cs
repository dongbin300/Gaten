using Gaten.Net.GameRule.RubiksCube.v2;

namespace Gaten.Study.TestConsole
{
    public partial class Program
    {
        public static void Main()
        {
            ValidRotationFilter filter = new ValidRotationFilter();
            filter.Load("RU.txt");

            filter.Filtering();
            filter.Save("VRU.txt");
        }
    }
}
