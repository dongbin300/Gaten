using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class PUNIChunk : Chunk
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="players">플레이어별 유닛 12*228 = 2736</param>
        /// <param name="globals">유닛 228</param>
        /// <param name="defaults">플레이어별 유닛 12*228 = 2736</param>
        public PUNIChunk(UnitSet unitSet)
        {
            Name = "PUNI";
            Size = 5700;

            Match(unitSet);
        }

        void Match(UnitSet unitSet)
        {
            for (int i = 0; i < 12; i++)
            {
                foreach (Unit unit in unitSet.Units)
                {
                    AddData(unit.PlayerAvailables[i]);
                }
            }

            foreach (Unit unit in unitSet.Units)
            {
                AddData(unit.GlobalAvailable);
            }

            for (int i = 0; i < 12; i++)
            {
                foreach (Unit unit in unitSet.Units)
                {
                    AddData(unit.UseDefaults[i]);
                }
            }
        }
    }
}
