using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class UNISChunk : Chunk
    {
        public UNISChunk(string name, int size, Unit unit)
        {
            Name = name;
            Size = size;

            AddData((byte)unit.SettingRule);
            AddData(unit.HP);
            AddData(unit.Shield);
            AddData(unit.Armor);
            AddData(unit.BuildTime);
            AddData(unit.Mineral);
            AddData(unit.Gas);
            AddData(unit.StringNumber);
        }
    }
}
