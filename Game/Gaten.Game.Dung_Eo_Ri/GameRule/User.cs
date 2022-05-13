using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Game.Dung_Eo_Ri.GameRule
{
    public class User : Organism
    {
        public Dungeon CurrentDungeon { get; set; }
        public int CurrentDungeonLevel { get; set; }
        public int CurrentCoordX { get; set; }
        public int CurrentCoordY { get; set; }
        public int CurrentExp { get; set; }

        public User(string name, Image picture, int level, int baseHitPoints, int baseDamage, List<Equip> equips) : base(name, picture, level, baseHitPoints, baseDamage, equips)
        {
        }

        public User(string name, Image picture) : base(name, picture)
        {
            Level = 1;
            UpdateStats();
        }

        public void UpdateStats()
        {
            BaseHitPoints = (Level - 1) * 30 + 500;
            CurrentHitPoints = GetMaxHitPoints();
            BaseDamage = Level + 4;
        }

        public void EnterDungeon(Dungeon dungeon)
        {
            CurrentDungeon = dungeon;
            CurrentDungeonLevel = 1;
            CurrentCoordX = 0;
            CurrentCoordY = 0;
        }

        public void GiveUpDungeon()
        {
            ApplyEndGameDefeatStatus();
        }

        public bool CanGoUp()
        {
            return CurrentCoordY - 1 >= 0;
        }

        public bool CanGoDown()
        {
            return CurrentCoordY + 1 < CurrentDungeon.DungeonLevels[CurrentDungeonLevel - 1].Height;
        }

        public bool CanGoLeft()
        {
            return CurrentCoordX - 1 >= 0;
        }

        public bool CanGoRight()
        {
            return CurrentCoordX + 1 < CurrentDungeon.DungeonLevels[CurrentDungeonLevel - 1].Width;
        }

        public void MoveUp()
        {
            if (CanGoUp())
            {
                CurrentCoordY--;
            }
        }

        public void MoveDown()
        {
            if (CanGoDown())
            {
                CurrentCoordY++;
            }
        }

        public void MoveLeft()
        {
            if (CanGoLeft())
            {
                CurrentCoordX--;
            }
        }

        public void MoveRight()
        {
            if (CanGoRight())
            {
                CurrentCoordX++;
            }
        }

        public void ApplyEndGameDefeatStatus()
        {
            CurrentExp -= CurrentDungeon.AccumulatedRewardExp;
            CurrentDungeon.AccumulatedRewardExp = 0;
        }

        public void ApplyEndGameVictoryStatus()
        {
            ApplyLevelUp();
            CurrentDungeon.AccumulatedRewardExp = 0;

        }

        public void ApplyLevelUp()
        {
            int requiredExp = GetLevelUpExp();
            while (CurrentExp >= requiredExp)
            {
                CurrentExp -= requiredExp;
                Level++;
                requiredExp = Level * 20;
            }
            UpdateStats();
        }

        public int GetLevelUpExp()
        {
            return Level * 20;
        }

        public void DescendDungeonLevel()
        {
            CurrentDungeonLevel++;
        }
    }
}
