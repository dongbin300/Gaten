using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class PTEXChunk : Chunk
    {
        public PTEXChunk(TechSet techSet)
        {
            Name = "PTEx";
            Size = 1672;

            Match(techSet);
        }

        void Match(TechSet techSet)
        {
            for (int i = 0; i < 12; i++)
            {
                foreach (Tech tech in techSet.Techs)
                {
                    AddData(tech.PlayerAvailables[i]);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                foreach (Tech tech in techSet.Techs)
                {
                    AddData(tech.PlayerResearched[i]);
                }
            }

            foreach (Tech tech in techSet.Techs)
            {
                AddData(tech.GlobalAvailable);
            }

            foreach (Tech tech in techSet.Techs)
            {
                AddData(tech.GlobalResearched);
            }

            for (int i = 0; i < 12; i++)
            {
                foreach (Tech tech in techSet.Techs)
                {
                    AddData(tech.UseDefaults[i]);
                }
            }
        }
    }
}
