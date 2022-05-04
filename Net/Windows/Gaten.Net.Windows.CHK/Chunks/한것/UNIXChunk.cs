using Gaten.Net.GameRule.StarCraft.PlaySystem;

namespace Gaten.Net.Windows.CHK.Chunks
{
    /// <summary>
    /// Unit Settings Chunk (UNIS)
    /// 
    /// 이름: UNIx
    /// 크기: 4168(고정)
    /// 구성: 유닛의 스탯정보(3648) + 무기의 스탯정보(520)
    /// 
    /// 유닛의 스탯정보(3648)
    /// Rule: Default or Custom [1*228]
    /// 
    /// 구분자: 00 [1]
    /// 
    /// HP: 체력 [4*228]
    /// 체력이 0/1인 일종의 무적유닛은 이전 유닛의 최상위바이트가 01로 표기됨
    /// Terran의 Unit Turret이 그러함
    /// 
    /// ...
    /// 
    /// 무기의 스탯정보(520)
    /// 
    /// 
    /// </summary>
    public class UNIXChunk : Chunk
    {
        public UNIXChunk(UnitSet unitSet, WeaponSet weaponSet)
        {
            Name = "UNIx";
            Size = 4168;

            Match(unitSet, weaponSet);
        }

        void Match(UnitSet unitSet, WeaponSet weaponSet)
        {
            foreach (Unit unit in unitSet.Units)
            {
                AddData((byte)unit.SettingRule);
            }
            foreach (Unit unit in unitSet.Units)
            {
                AddData(unit.HP * 256);
            }
            foreach (Unit unit in unitSet.Units)
            {
                AddData(unit.Shield);
            }
            foreach (Unit unit in unitSet.Units)
            {
                AddData(unit.Armor);
            }
            foreach (Unit unit in unitSet.Units)
            {
                AddData(unit.BuildTime);
            }
            foreach (Unit unit in unitSet.Units)
            {
                AddData(unit.Mineral);
            }
            foreach (Unit unit in unitSet.Units)
            {
                AddData(unit.Gas);
            }
            foreach (Unit unit in unitSet.Units)
            {
                AddData(unit.StringNumber);
            }

            foreach (Weapon weapon in weaponSet.Weapons)
            {
                AddData(weapon.Power);
            }
            foreach (Weapon weapon in weaponSet.Weapons)
            {
                AddData(weapon.PowerBonus);
            }
        }
    }
}
