using Gaten.Net.Extension;

namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class Wav
    {
        public static uint[] MPQPath { get; set; }

        public Wav()
        {
            MPQPath = new uint[512];

            MakeDefault();
        }

        void MakeDefault()
        {
            MPQPath.Fill((uint)0);
        }
    }
}
