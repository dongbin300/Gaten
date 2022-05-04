using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class TECXChunk : Chunk
    {
        public TECXChunk(TechSet techSet)
        {
            Name = "TECx";
            Size = 396;

            Match(techSet);
        }

        void Match(TechSet techSet)
        {
            foreach(Tech tech in techSet.Techs)
            {
                AddData((byte)tech.SettingRule);
            }

            foreach (Tech tech in techSet.Techs)
            {
                AddData(tech.Mineral);
            }

            foreach (Tech tech in techSet.Techs)
            {
                AddData(tech.Gas);
            }

            foreach (Tech tech in techSet.Techs)
            {
                AddData(tech.Time);
            }

            foreach (Tech tech in techSet.Techs)
            {
                AddData(tech.Energy);
            }
        }
    }
}
