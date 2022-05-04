namespace Gaten.Game.NGDG2.Screen
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
            ScreenUtil.Stack(Character.Name);
            ScreenUtil.Stack(Character.Class.Value);
            ScreenUtil.Stack($"Lv {Character.Level}");
            ScreenUtil.Stack($"HP {Character.TotalAbility.HPMax}");
            ScreenUtil.Stack($"MP {Character.TotalAbility.MPMax}");
            ScreenUtil.Stack($"힘 {Character.TotalAbility.Power}");
            ScreenUtil.Stack($"체력 {Character.TotalAbility.Stamina}");
            ScreenUtil.Stack($"지능 {Character.TotalAbility.Intelli}");
            ScreenUtil.Stack($"정신력 {Character.TotalAbility.Willpower}");
            ScreenUtil.Stack($"집중력 {Character.TotalAbility.Concentration}");
            ScreenUtil.Stack($"민첩 {Character.TotalAbility.Agility}");
            ScreenUtil.Stack($"공격력 {Character.TotalAbility.Attack}");
            ScreenUtil.Stack($"방어력 {Character.TotalAbility.Defense}");
            ScreenUtil.Stack($"공격속도 {Character.TotalAbility.AttackSpeed}({Character.TotalAbility.CoolTick})");
            ScreenUtil.Stack($"명중률 {string.Format("{0:F2}%", Character.TotalAbility.Accuracy)}");
            ScreenUtil.Stack($"회피율 {string.Format("{0:F2}%", Character.TotalAbility.EvasionRate)}");
            ScreenUtil.Stack($"HP회복 {Character.TotalAbility.HPRec}");
            ScreenUtil.Stack($"MP회복 {Character.TotalAbility.MPRec}");

            // 장착중인 장비
            CHelper.Write($"무기 / {Character.MountEquipments.GetEquipment(Item.EquipmentPart.Weapon).Name}", 50, 3);
            CHelper.Write($"모자 / {Character.MountEquipments.GetEquipment(Item.EquipmentPart.Helmet).Name}", 50, 4);
            CHelper.Write($"상의 / {Character.MountEquipments.GetEquipment(Item.EquipmentPart.Armor).Name}", 50, 5);
            CHelper.Write($"하의 / {Character.MountEquipments.GetEquipment(Item.EquipmentPart.Trouser).Name}", 50, 6);
            CHelper.Write($"신발 / {Character.MountEquipments.GetEquipment(Item.EquipmentPart.Shoes).Name}", 50, 7);
            CHelper.Write($"목걸이 / {Character.MountEquipments.GetEquipment(Item.EquipmentPart.Necklace).Name}", 50, 8);
            CHelper.Write($"반지 / {Character.MountEquipments.GetEquipment(Item.EquipmentPart.Ring).Name}", 50, 9);
            CHelper.Write($"엠블렘 / {Character.MountEquipments.GetEquipment(Item.EquipmentPart.Emblem).Name}", 50, 10);
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
