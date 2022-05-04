using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class UPGXChunk : Chunk
    {
        public UPGXChunk(UpgradeSet upgradeSet)
        {
            Name = "UPGx";
            Size = 794;

            Match(upgradeSet);
        }

        void Match(UpgradeSet upgradeSet)
        {
            foreach(Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData((byte)upgrade.SettingRule);
            }

            AddData(0); // Unused

            foreach (Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData(upgrade.Mineral);
            }

            foreach (Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData(upgrade.MineralBonus);
            }

            foreach (Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData(upgrade.Gas);
            }

            foreach (Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData(upgrade.GasBonus);
            }

            foreach (Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData(upgrade.Time);
            }

            foreach (Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData(upgrade.TimeBonus);
            }
        }
    }
}
