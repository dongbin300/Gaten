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
            BaseHitPoints = Level * 10 + 90;
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
    }
}
