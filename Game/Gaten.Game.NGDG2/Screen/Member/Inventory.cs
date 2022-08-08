using Gaten.Game.NGDG2.GameRule.Character;
using Gaten.Game.NGDG2.GameRule.Item;
using Gaten.Game.NGDG2.Screen.Interface;
using Gaten.Game.NGDG2.Util.Math;
using Gaten.Game.NGDG2.Util.Screen;

namespace Gaten.Game.NGDG2.Screen.Member
{
    public class Inventory : IScreen
    {
        private string keyLog = string.Empty;
        private NgdgItem selectedItem = new();

        public Inventory()
        {
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("인벤토리", ConsoleColor.Green);

            // 바로가기
            ScreenUtil.DrawHotKeyNavigator(new HotKeyNavigator().AddHotKey("SPACE", "장착/사용").AddHotKey("S", "판매").AddHotKey("ESC", "뒤로가기"));

            // 아이템 번호
            for (int i = 0; i < 36; i++)
            {
                ScreenUtil.Stack(string.Format("{0:00}", i + 1) + " | ");
            }

            // 인벤토리 슬롯
            for (int i = 0; i < NgdgCharacter.Inventory.Slots.Count; i++)
            {
                NgdgSlot slot = NgdgCharacter.Inventory.Slots[i];

                if (slot.Item == null)
                {
                    continue;
                }

                CHelper.Write(string.Format("{0,-20}[{1}]", slot.Item.Name, slot.ItemCount), 8 + (20 * (i / 10)), 3 + (i % 10), slot.Item.Color);
            }

            // 구분자
            ScreenUtil.DrawVerticalSeparator(70);

            // 아이템 정보
            if (selectedItem != null)
            {
                // 아이템 이름
                CHelper.Write(selectedItem.Name, 72, 3, selectedItem.Color);

                // 아이템 사용/장착 레벨
                if (selectedItem.Level != 0)
                {
                    CHelper.Write($"레벨 {selectedItem.Level}", 72, 4);
                }

                // 장비 효과 / 아이템 설명
                switch (selectedItem.Type)
                {
                    case NgdgItem.ItemType.Material:
                        CHelper.Write(selectedItem.Description, 72, 6);
                        break;

                    case NgdgItem.ItemType.Potion:
                        CHelper.Write(selectedItem.Description, 72, 6);
                        break;

                    case NgdgItem.ItemType.Equipment:
                        for (int i = 0; i < selectedItem.EffectStrings.Count; i++)
                        {
                            CHelper.Write(selectedItem.EffectStrings[i], 72, 6 + i);
                        }
                        break;
                }

                // 판매 금액
                CHelper.Write($"{selectedItem.SalePrice} 골드", 72, 38);
            }
        }

        public string React(ConsoleKey key)
        {
            SmartRandom r = new();

            switch (key)
            {
                // 아이템 선택
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                case ConsoleKey.D6:
                case ConsoleKey.D7:
                case ConsoleKey.D8:
                case ConsoleKey.D9:
                case ConsoleKey.D0:
                    if (keyLog.Length == 2)
                    {
                        keyLog = string.Empty;
                    }

                    keyLog += ((int)key - 48).ToString();

                    if (keyLog.Length == 2)
                    {
                        int num = int.Parse(keyLog);

                        if (num >= 1 && num <= NgdgCharacter.Inventory.Slots.Count)
                        {
                            selectedItem = NgdgCharacter.Inventory.Slots[num - 1].Item;
                        }
                    }
                    break;

                // 아이템 판매
                case ConsoleKey.S:
                    if (selectedItem != null)
                    {
                        // 선택한 아이템이 인벤토리에 있으면 판매
                        if (NgdgCharacter.Inventory.HasItem(selectedItem))
                        {
                            NgdgCharacter.Inventory.Remove(selectedItem);
                            NgdgCharacter.Gold += selectedItem.SalePrice;
                        }
                    }
                    break;

                // 아이템 사용/장착
                case ConsoleKey.Spacebar:
                    if (selectedItem != null)
                    {
                        // 선택한 아이템이 인벤토리에 있으면 사용/장착
                        if (NgdgCharacter.Inventory.HasItem(selectedItem))
                        {
                            switch (selectedItem.Type)
                            {
                                case NgdgItem.ItemType.Material:
                                    switch (selectedItem.Name)
                                    {
                                        case "1레벨 낡은 장비 상자":
                                            string[] list1 = { "낡은 검", "낡은 지팡이", "낡은 총", "낡은 가죽헬멧", "낡은 금속헬멧", "낡은 가죽아머", "낡은 금속아머", "낡은 가죽트라우저", "낡은 금속트라우저", "낡은 가죽슈즈", "낡은 금속슈즈", "낡은 강철목걸이", "낡은 합금목걸이", "낡은 강철반지", "낡은 합금반지", "낡은 엠블렘" };
                                            NgdgCharacter.Inventory.Add(NgdgItemDictionary.MakeItem(list1[r.Next(list1.Length)]));
                                            NgdgCharacter.Inventory.Remove(selectedItem);
                                            break;

                                        case "5레벨 평범한 장비 상자":
                                            string[] list2 = { "평범한 검", "평범한 지팡이", "평범한 총", "평범한 가죽헬멧", "평범한 금속헬멧", "평범한 가죽아머", "평범한 금속아머", "평범한 가죽트라우저", "평범한 금속트라우저", "평범한 가죽슈즈", "평범한 금속슈즈", "평범한 강철목걸이", "평범한 합금목걸이", "평범한 강철반지", "평범한 합금반지", "평범한 엠블렘" };
                                            NgdgCharacter.Inventory.Add(NgdgItemDictionary.MakeItem(list2[r.Next(list2.Length)]));
                                            NgdgCharacter.Inventory.Remove(selectedItem);
                                            break;
                                    }
                                    break;

                                case NgdgItem.ItemType.Potion:
                                    break;

                                case NgdgItem.ItemType.Equipment:
                                    _ = NgdgCharacter.MountEquipments.Equip(selectedItem);
                                    break;
                            }
                        }
                    }
                    break;

                case ConsoleKey.Escape:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
                    break;
            }

            return string.Empty;
        }
    }
}
