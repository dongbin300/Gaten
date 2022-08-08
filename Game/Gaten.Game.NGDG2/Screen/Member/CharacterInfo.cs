using Gaten.Game.NGDG2.GameRule.Character;
using Gaten.Game.NGDG2.GameRule.Item;
using Gaten.Game.NGDG2.Screen.Interface;
using Gaten.Game.NGDG2.Util.Screen;

namespace Gaten.Game.NGDG2.Screen.Member
{
    public class CharacterInfo : IScreen
    {
        public CharacterInfo()
        {
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("캐릭터 정보", ConsoleColor.Green);

            // 바로가기
            ScreenUtil.DrawHotKeyNavigator(new HotKeyNavigator().AddHotKey("ESC", "뒤로가기"));

            // 캐릭터 스탯
            ScreenUtil.Stack(NgdgCharacter.Name);
            ScreenUtil.Stack(NgdgCharacter.Class.Value);
            ScreenUtil.Stack($"Lv {NgdgCharacter.Level}");
            ScreenUtil.Stack($"HP {NgdgCharacter.TotalAbility.HPMax}");
            ScreenUtil.Stack($"MP {NgdgCharacter.TotalAbility.MPMax}");
            ScreenUtil.Stack($"힘 {NgdgCharacter.TotalAbility.Power}");
            ScreenUtil.Stack($"체력 {NgdgCharacter.TotalAbility.Stamina}");
            ScreenUtil.Stack($"지능 {NgdgCharacter.TotalAbility.Intelli}");
            ScreenUtil.Stack($"정신력 {NgdgCharacter.TotalAbility.Willpower}");
            ScreenUtil.Stack($"집중력 {NgdgCharacter.TotalAbility.Concentration}");
            ScreenUtil.Stack($"민첩 {NgdgCharacter.TotalAbility.Agility}");
            ScreenUtil.Stack($"공격력 {NgdgCharacter.TotalAbility.Attack}");
            ScreenUtil.Stack($"방어력 {NgdgCharacter.TotalAbility.Defense}");
            ScreenUtil.Stack($"공격속도 {NgdgCharacter.TotalAbility.AttackSpeed}({NgdgCharacter.TotalAbility.CoolTick})");
            ScreenUtil.Stack($"명중률 {string.Format("{0:F2}%", NgdgCharacter.TotalAbility.Accuracy)}");
            ScreenUtil.Stack($"회피율 {string.Format("{0:F2}%", NgdgCharacter.TotalAbility.EvasionRate)}");
            ScreenUtil.Stack($"HP회복 {NgdgCharacter.TotalAbility.HPRec}");
            ScreenUtil.Stack($"MP회복 {NgdgCharacter.TotalAbility.MPRec}");

            // 장착중인 장비
            CHelper.Write($"무기 / {NgdgCharacter.MountEquipments.GetEquipment(NgdgItem.EquipmentPart.Weapon).Name}", 50, 3);
            CHelper.Write($"모자 / {NgdgCharacter.MountEquipments.GetEquipment(NgdgItem.EquipmentPart.Helmet).Name}", 50, 4);
            CHelper.Write($"상의 / {NgdgCharacter.MountEquipments.GetEquipment(NgdgItem.EquipmentPart.Armor).Name}", 50, 5);
            CHelper.Write($"하의 / {NgdgCharacter.MountEquipments.GetEquipment(NgdgItem.EquipmentPart.Trouser).Name}", 50, 6);
            CHelper.Write($"신발 / {NgdgCharacter.MountEquipments.GetEquipment(NgdgItem.EquipmentPart.Shoes).Name}", 50, 7);
            CHelper.Write($"목걸이 / {NgdgCharacter.MountEquipments.GetEquipment(NgdgItem.EquipmentPart.Necklace).Name}", 50, 8);
            CHelper.Write($"반지 / {NgdgCharacter.MountEquipments.GetEquipment(NgdgItem.EquipmentPart.Ring).Name}", 50, 9);
            CHelper.Write($"엠블렘 / {NgdgCharacter.MountEquipments.GetEquipment(NgdgItem.EquipmentPart.Emblem).Name}", 50, 10);
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
                    break;
            }

            return string.Empty;
        }
    }
}
