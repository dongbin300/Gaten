using Gaten.Game.NGDG2.Util.Expression;

namespace Gaten.Game.NGDG2.GameRule.Item
{
    /// <summary>
    /// 게임 내 모든 아이템 (장비도 포함)
    /// TODO :: 아이템, 스킬, 몬스터 등등 데이터가 많을것같은 정보들을 담고 있느 파일 포맷 하나 만들어야 하는데NFD
    /// Material.NFD, Potion.NFD, Equipment.NFD, Skill.NFD, Monster.NFD
    /// </summary>
    public class NgdgItem
    {
        /// <summary>
        /// 아이템 유형
        /// 재료 - 각종 재료 아이템
        /// 포션 - 회복 아이템
        /// 장비 - 무기, 방어구, 악세서리, 엠블렘 아이템
        /// </summary>
        public enum ItemType
        {
            Material,
            Potion,
            Equipment
        }

        /// <summary>
        /// 아이템 등급
        /// 노말 - 하얀색
        /// 익시드 - 노란색
        /// 레어 - 하늘색
        /// 아티팩트 - 초록색
        /// 유니크 - 분홍색
        /// 에픽 - 빨간색
        /// </summary>
        public enum ItemRank
        {
            Normal,
            Exceed,
            Rare,
            Artifact,
            Unique,
            Epic
        }

        /// <summary>
        /// 아이템 유형
        /// </summary>
        public ItemType Type;

        /// <summary>
        /// 아이템 이름(ID)
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// 아이템 사용/장착레벨(기본 0)
        /// </summary>
        public int Level;

        /// <summary>
        /// 아이템 설명
        /// </summary>
        public string Description = string.Empty;

        /// <summary>
        /// 아이템 효과 문자열
        /// </summary>
        public List<string> EffectStrings = new();

        /// <summary>
        /// 아이템 부위 문자열
        /// </summary>
        public string PartString = string.Empty;

        /// <summary>
        /// 아이템 가치
        /// </summary>
        public int Value;

        /// <summary>
        /// 아이템 판매 가격
        /// 아이템 가치의 1/4
        /// </summary>
        public int SalePrice => Value / 4;

        /// <summary>
        /// 아이템 등급
        /// </summary>
        public ItemRank Rank;

        /// <summary>
        /// 아이템 이름 색상
        /// </summary>
        public ConsoleColor Color => GetColor(Rank);

        /// <summary>
        /// 장비 유형
        /// </summary>
        public enum EquipmentType
        {
            None,
            Sword,
            Staff,
            Gun,
            LeatherHelmet,
            MetalHelmet,
            LeatherArmor,
            MetalArmor,
            LeatherTrouser,
            MetalTrouser,
            LeatherShoes,
            MetalShoes,
            SteelNecklace,
            AlloyNecklace,
            SteelRing,
            AlloyRing,
            Emblem
        }

        /// <summary>
        /// 장비 부위
        /// </summary>
        public enum EquipmentPart
        {
            None,
            Weapon,
            Helmet,
            Armor,
            Trouser,
            Shoes,
            Necklace,
            Ring,
            Emblem
        }

        /// <summary>
        /// 장비 유형
        /// </summary>
        public EquipmentType EqType;

        /// <summary>
        /// 장비 부위
        /// </summary>
        public EquipmentPart Part => GetEquipmentPart(EqType);

        /// <summary>
        /// 장착 효과
        /// </summary>
        public NgdgAbility Effect = new();

        /// <summary>
        /// 장비 효과 정보
        /// </summary>
        public string FormattedEquipmentEffect = string.Empty;

        /// <summary>
        /// 포션 효과 정보
        /// </summary>
        public string FormattedPotionEffect = string.Empty;

        public NgdgItem()
        {

        }

        /// <summary>
        /// [생성자] 장비 아이템을 설정한다.
        /// </summary>
        /// <param name="name">이름</param>
        /// <param name="level">장착 최소레벨</param>
        /// <param name="equipmentType">장비 유형</param>
        /// <param name="itemRank">아이템 등급</param>
        /// <param name="formattedEquipmentEffect">장비 효과 정보, ex) "p15/s10/i7/w8/c12/a13/h150/m120/x4/y3/t165/d138/e25" => 힘 +15, 체력 +10, 지능 +7, 정신력 +8, 집중력 +12, 민첩 +13, HP MAX +150, MP MAX +120, HP회복 +4, MP회복 +3, 공격력 +165, 방어력 +138, 공격속도 +25</param>
        public NgdgItem(string name, int level, string equipmentType, string itemRank, string formattedEquipmentEffect)
        {
            Type = ItemType.Equipment;

            Name = name;
            Level = level;

            switch (equipmentType)
            {
                case "0":
                    EqType = EquipmentType.None;
                    break;
                case "1":
                    EqType = EquipmentType.Sword;
                    break;
                case "2":
                    EqType = EquipmentType.Staff;
                    break;
                case "3":
                    EqType = EquipmentType.Gun;
                    break;
                case "4":
                    EqType = EquipmentType.LeatherHelmet;
                    break;
                case "5":
                    EqType = EquipmentType.MetalHelmet;
                    break;
                case "6":
                    EqType = EquipmentType.LeatherArmor;
                    break;
                case "7":
                    EqType = EquipmentType.MetalArmor;
                    break;
                case "8":
                    EqType = EquipmentType.LeatherTrouser;
                    break;
                case "9":
                    EqType = EquipmentType.MetalTrouser;
                    break;
                case "10":
                    EqType = EquipmentType.LeatherShoes;
                    break;
                case "11":
                    EqType = EquipmentType.MetalShoes;
                    break;
                case "12":
                    EqType = EquipmentType.SteelNecklace;
                    break;
                case "13":
                    EqType = EquipmentType.AlloyNecklace;
                    break;
                case "14":
                    EqType = EquipmentType.SteelRing;
                    break;
                case "15":
                    EqType = EquipmentType.AlloyRing;
                    break;
                case "16":
                    EqType = EquipmentType.Emblem;
                    break;
            }

            switch (itemRank)
            {
                case "1":
                    Rank = ItemRank.Normal;
                    break;
                case "2":
                    Rank = ItemRank.Exceed;
                    break;
                case "3":
                    Rank = ItemRank.Rare;
                    break;
                case "4":
                    Rank = ItemRank.Artifact;
                    break;
                case "5":
                    Rank = ItemRank.Unique;
                    break;
                case "6":
                    Rank = ItemRank.Epic;
                    break;
            }

            FormattedEquipmentEffect = formattedEquipmentEffect;
        }

        /// <summary>
        /// [생성자] 재료 아이템을 설정한다.
        /// </summary>
        /// <param name="name">이름</param>
        /// <param name="itemRank">아이템 등급</param>
        /// <param name="description">아이템 설명</param>
        /// <param name="value">아이템 가치</param>
        /// <param name="level">아이템 레벨</param>
        public NgdgItem(string name, string itemRank, string description, int value, int level)
        {
            Type = ItemType.Material;

            Name = name;

            switch (itemRank)
            {
                case "1":
                    Rank = ItemRank.Normal;
                    break;
                case "2":
                    Rank = ItemRank.Exceed;
                    break;
                case "3":
                    Rank = ItemRank.Rare;
                    break;
                case "4":
                    Rank = ItemRank.Artifact;
                    break;
                case "5":
                    Rank = ItemRank.Unique;
                    break;
                case "6":
                    Rank = ItemRank.Epic;
                    break;
            }

            Description = description;
            Value = value;
            Level = level;
        }

        /// <summary>
        /// [생성자] 포션 아이템을 설정한다.
        /// </summary>
        /// <param name="name">이름</param>
        /// <param name="itemRank">아이템 등급</param>
        /// <param name="description">아이템 설명</param>
        /// <param name="value">아이템 가치</param>
        /// <param name="level">사용 최소레벨</param>
        /// <param name="formattedPotionEffect">포션 효과 정보, ex)</param>
        public NgdgItem(string name, string itemRank, string description, int value, int level, string formattedPotionEffect)
        {
            Type = ItemType.Potion;

            Name = name;

            switch (itemRank)
            {
                case "1":
                    Rank = ItemRank.Normal;
                    break;
                case "2":
                    Rank = ItemRank.Exceed;
                    break;
                case "3":
                    Rank = ItemRank.Rare;
                    break;
                case "4":
                    Rank = ItemRank.Artifact;
                    break;
                case "5":
                    Rank = ItemRank.Unique;
                    break;
                case "6":
                    Rank = ItemRank.Epic;
                    break;
            }

            Description = description;
            Value = value;
            Level = level;
            FormattedPotionEffect = formattedPotionEffect;
        }

        /// <summary>
        /// 장비 아이템을 만든다.
        /// </summary>
        /// <returns></returns>
        public NgdgItem MakeEquipment(NgdgItem frame)
        {
            Type = ItemType.Equipment;

            Name = frame.Name;
            Level = frame.Level;
            EqType = frame.EqType;
            Rank = frame.Rank;

            Effect = new NgdgAbility(NgdgAbility.CalculateRule.Equipment);
            Effect.Reset();
            EffectStrings = new List<string>();

            FormattedEquipmentEffect = frame.FormattedEquipmentEffect;

            // 효과가 없는 장비
            if (StringUtil.IsEmpty(FormattedEquipmentEffect))
            {
                return this;
            }

            // 효과 파싱
            string[] effects = FormattedEquipmentEffect.Split('/');

            foreach (string effect in effects)
            {
                // 효과 유형 분석
                string effectTypeString = effect[..1];

                // 효과 값 분석
                int value = int.Parse(effect[1..]);

                switch (effectTypeString)
                {
                    case "p":
                        Effect.Power = value;
                        EffectStrings.Add($"힘 +{value}");
                        break;
                    case "s":
                        Effect.Stamina = value;
                        EffectStrings.Add($"체력 +{value}");
                        break;
                    case "i":
                        Effect.Intelli = value;
                        EffectStrings.Add($"지능 +{value}");
                        break;
                    case "w":
                        Effect.Willpower = value;
                        EffectStrings.Add($"정신력 +{value}");
                        break;
                    case "c":
                        Effect.Concentration = value;
                        EffectStrings.Add($"집중력 +{value}");
                        break;
                    case "a":
                        Effect.Agility = value;
                        EffectStrings.Add($"민첩 +{value}");
                        break;
                    case "h":
                        Effect.HPMax = value;
                        EffectStrings.Add($"HP MAX +{value}");
                        break;
                    case "x":
                        Effect.HPRec = value;
                        EffectStrings.Add($"HP회복 +{value}");
                        break;
                    case "m":
                        Effect.MPMax = value;
                        EffectStrings.Add($"MP MAX +{value}");
                        break;
                    case "y":
                        Effect.MPRec = value;
                        EffectStrings.Add($"MP회복 +{value}");
                        break;
                    case "t":
                        Effect.Attack = value;
                        EffectStrings.Add($"공격력 +{value}");
                        break;
                    case "d":
                        Effect.Defense = value;
                        EffectStrings.Add($"방어력 +{value}");
                        break;
                    case "e":
                        Effect.AttackSpeed = value;
                        EffectStrings.Add($"공격속도 +{value}");
                        break;
                }
            }

            return this;
        }

        /// <summary>
        /// 재료 아이템을 만든다.
        /// </summary>
        /// <returns></returns>
        public NgdgItem MakeMaterial(NgdgItem frame)
        {
            Type = ItemType.Material;

            Name = frame.Name;
            Rank = frame.Rank;
            Description = frame.Description;
            Value = frame.Value;
            Level = frame.Level;

            return this;
        }

        /// <summary>
        /// 포션 아이템을 만든다.
        /// </summary>
        /// <returns></returns>
        public NgdgItem MakePotion(NgdgItem frame)
        {
            Type = ItemType.Potion;

            Name = frame.Name;
            Rank = frame.Rank;
            Description = frame.Description;
            Value = frame.Value;
            Level = frame.Level;

            // TODO: formattedPotionEffect

            return this;
        }

        /// <summary>
        /// 아이템 등급에 따른 이름 색상
        /// </summary>
        /// <param name="rank">아이템 등급</param>
        /// <returns>이름 색상</returns>
        private ConsoleColor GetColor(ItemRank rank)
        {
            return rank switch
            {
                ItemRank.Normal => ConsoleColor.White,
                ItemRank.Exceed => ConsoleColor.Yellow,
                ItemRank.Rare => ConsoleColor.Cyan,
                ItemRank.Artifact => ConsoleColor.Green,
                ItemRank.Unique => ConsoleColor.Magenta,
                ItemRank.Epic => ConsoleColor.Red,
                _ => ConsoleColor.White,
            };
        }

        public string GetPartString(EquipmentPart part)
        {
            return part switch
            {
                EquipmentPart.None => "",
                EquipmentPart.Weapon => "무기",
                EquipmentPart.Helmet => "모자",
                EquipmentPart.Armor => "상의",
                EquipmentPart.Trouser => "하의",
                EquipmentPart.Shoes => "신발",
                EquipmentPart.Necklace => "목걸이",
                EquipmentPart.Ring => "반지",
                EquipmentPart.Emblem => "엠블렘",
                _ => "",
            };
        }

        /// <summary>
        /// 장비 유형으로 장비 부위를 구합니다.
        /// </summary>
        /// <param name="type">장비 유형</param>
        /// <returns>장비 부위</returns>
        public EquipmentPart GetEquipmentPart(EquipmentType type)
        {
            return type switch
            {
                EquipmentType.Sword or EquipmentType.Staff or EquipmentType.Gun => EquipmentPart.Weapon,
                EquipmentType.LeatherHelmet or EquipmentType.MetalHelmet => EquipmentPart.Helmet,
                EquipmentType.LeatherArmor or EquipmentType.MetalArmor => EquipmentPart.Armor,
                EquipmentType.LeatherTrouser or EquipmentType.MetalTrouser => EquipmentPart.Trouser,
                EquipmentType.LeatherShoes or EquipmentType.MetalShoes => EquipmentPart.Shoes,
                EquipmentType.SteelNecklace or EquipmentType.AlloyNecklace => EquipmentPart.Necklace,
                EquipmentType.SteelRing or EquipmentType.AlloyRing => EquipmentPart.Ring,
                EquipmentType.Emblem => EquipmentPart.Emblem,
                _ => EquipmentPart.None,
            };
        }
    }
}
