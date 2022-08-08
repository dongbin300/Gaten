using Gaten.Net.Extensions;

namespace Gaten.Net.GameRule.StarCraft.Script
{
    public class String
    {
        public uint StringCount { get; set; }
        public uint[] Offsets { get; set; }
        public string[] Data { get; set; }

        public String()
        {
            Offsets = new uint[1024];
            Data = new string[1024];

            MakeDefault();
        }

        void MakeDefault()
        {
            StringCount = 1024;

            Offsets.Fill((uint)4100);
            Offsets[0] = 4101;
            Offsets[1] = 4119;
            Offsets[2] = 4148;
            Offsets[3] = 4157;
            Offsets[4] = 4165;
            Offsets[5] = 4173;
            Offsets[6] = 4181;

            Data[0] = "Untitled Scenario";
            Data[1] = "Destroy all enemy buildings.";
            Data[2] = "Anywhere";
            Data[3] = "Force 1";
            Data[4] = "Force 2";
            Data[5] = "Force 3";
            Data[6] = "Force 4";
        }
    }
}
