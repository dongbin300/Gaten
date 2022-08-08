using Gaten.Net.Extensions;

namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class Wav
    {
        public static uint[] MPQPath { get; set; } = new uint[512];

        public Wav()
        {
            MakeDefault();
        }

        void MakeDefault()
        {
            MPQPath.Fill((uint)0);
        }
    }
}
