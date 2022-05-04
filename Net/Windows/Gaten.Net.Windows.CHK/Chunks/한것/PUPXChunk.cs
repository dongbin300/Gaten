using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    public class PUPXChunk : Chunk
    {
        public PUPXChunk(UpgradeSet upgradeSet)
        {
            Name = "PUPx";
            Size = 2318;

            Match(upgradeSet);
        }

        void Match(UpgradeSet upgradeSet)
        {
            for (int i = 0; i < 12; i++)
            {
                foreach (Upgrade upgrade in upgradeSet.Upgrades)
                {
                    AddData(upgrade.PlayerMaxLevels[i]);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                foreach (Upgrade upgrade in upgradeSet.Upgrades)
                {
                    AddData(upgrade.PlayerStartLevels[i]);
                }
            }

            foreach (Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData(upgrade.GlobalMaxLevel);
            }

            foreach (Upgrade upgrade in upgradeSet.Upgrades)
            {
                AddData(upgrade.GlobalStartLevel);
            }

            for (int i = 0; i < 12; i++)
            {
                foreach (Upgrade upgrade in upgradeSet.Upgrades)
                {
                    AddData(upgrade.UseDefaults[i]);
                }
            }
        }
    }
}
