using System.Text;

namespace Gaten.Game.NGDG2
{
    /// <summary>
    /// 게임 내 캐릭터
    /// 캐릭터는 1개뿐이므로 static으로 구현
    /// </summary>
    public class Character
    {
        /// <summary>
        /// 캐릭터 닉네임(ID)
        /// </summary>
        public static string Name;

        /// <summary>
        /// 레벨
        /// </summary>
        private static int level;
        public static int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                RExp = (int)(333 * Math.Pow(level + 1, 1.72));
            }
        }

        /// <summary>
        /// 경험치
        /// </summary>
        private static long exp;
        public static long Exp
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
                if (exp >= rexp)
                {
                    Exp -= rexp;
                    Level++;
                }
            }
        }

        /// <summary>
        /// 현재 레벨의 필요 경험치
        /// </summary>
        private static long rexp;
        public static long RExp
        {
            get
            {
                return rexp;
            }
            set
            {
                rexp = value;
            }
        }

        /// <summary>
        /// 직업
        /// </summary>
        public static Class Class;

        /// <summary>
        /// 소지하고 있는 골드
        /// </summary>
        public static long Gold;

        /// <summary>
        /// 인벤토리
        /// 소지하고 있는 아이템들이 들어있다.
        /// </summary>
        public static Inventory Inventory;

        /// <summary>
        /// 장착중인 장비
        /// </summary>
        public static EquipmentSystem MountEquipments;

        /// <summary>
        /// 스킬북
        /// 배운 스킬들이 들어있다.
        /// </summary>
        public static SkillBook SkillBook;

        /// <summary>
        /// 계산된 종합 캐릭터 능력치
        /// </summary>
        public static Ability TotalAbility;

        /// <summary>
        /// 공격 쿨타임 타이머
        /// </summary>
        public static int AttackCool;

        public Character()
        {
            Class = new Class();
            Inventory = new Inventory(36);
            MountEquipments = new EquipmentSystem();
            SkillBook = new SkillBook(10);

            TotalAbility = new Ability(Ability.CalculateRule.Character);
        }

        /// <summary>
        /// 캐릭터에 관련된 모든 것을 연산한다.
        /// </summary>
        public static void Calculate()
        {
            // 공격 쿨타임
            // 1틱에 1씩 증가, 공격속도에 도달하면 증가하지 않는다.
            AttackCool = Math.Min(AttackCool + 1, TotalAbility.CoolTick);

            // 자동 HP, MP 회복
            RecoveryHP(TotalAbility.HPRec);
            RecoveryMP(TotalAbility.MPRec);

            // 캐릭터 능력치 재계산
            TotalAbility.Calculate();
        }

        /// <summary>
        /// 캐릭터에 적용된 버프나 시스템 등을 해제한다.
        /// 이 기능은 던전 입장 시 사용된다.
        /// </summary>
        public static void Reset()
        {
            TotalAbility.HP = TotalAbility.HPMax;
            TotalAbility.MP = TotalAbility.MPMax;
            AttackCool = 0;
        }

        /// <summary>
        /// HP를 회복한다.
        /// </summary>
        /// <param name="value"></param>
        public static void RecoveryHP(long value)
        {
            TotalAbility.HP += value;
            TotalAbility.HP = TotalAbility.HP > TotalAbility.HPMax ? TotalAbility.HPMax : TotalAbility.HP;
        }

        /// <summary>
        /// MP를 회복한다.
        /// </summary>
        /// <param name="value"></param>
        public static void RecoveryMP(long value)
        {
            TotalAbility.MP += value;
            TotalAbility.MP = TotalAbility.MP > TotalAbility.MPMax ? TotalAbility.MPMax : TotalAbility.MP;
        }

        /// <summary>
        /// 파일에서 캐릭터 데이터를 불러온다.
        /// 닉네임, 레벨, 경험치, 직업, 골드, 아이템, 장착중인 장비, 스킬
        /// </summary>
        /// <param name="fileName">캐릭터 파일 이름</param>
        public static void LoadFromFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    try
                    {
                        /* * * * Format * * *
                        * MyNickName
                        * 12
                        * 7789
                        * Gunner
                        * 5815
                        * 
                        * [Item]
                        * 붉은 구슬|24
                        * 초콜릿3|21
                        * 비밀상자|1
                        * *
                        * [MountEquipment]
                        * 견고한 투구
                        * 견고한 갑옷
                        * 견고한 부츠
                        * *
                        * [Skill]
                        * 스킬이름1|2
                        * 스킬이름2|12
                        * 스킬이름3|1
                        * *
                        * ***
                        */

                        bool End = false;

                        Name = reader.ReadLine();
                        Level = int.Parse(reader.ReadLine());
                        Exp = long.Parse(reader.ReadLine());
                        Class = new Class(reader.ReadLine());
                        Gold = long.Parse(reader.ReadLine());
                        reader.ReadLine();

                        while (true)
                        {
                            string keyword = reader.ReadLine();

                            switch (keyword)
                            {
                                case "[Item]":
                                    while (true)
                                    {
                                        string str = reader.ReadLine();

                                        if (str == "*")
                                            break;

                                        string[] data = str.Split('|');

                                        Inventory.Add(ItemDictionary.MakeItem(data[0]), int.Parse(data[1]));
                                    }
                                    break;
                                case "[MountEquipment]":
                                    while (true)
                                    {
                                        string str = reader.ReadLine();

                                        if (str == "*")
                                            break;

                                        MountEquipments.Add(ItemDictionary.MakeItem(str));
                                    }
                                    break;
                                case "[Skill]":
                                    while (true)
                                    {
                                        string str = reader.ReadLine();

                                        if (str == "*")
                                            break;

                                        string[] data = str.Split('|');

                                        SkillBook.Add(new Skill(data[0]), int.Parse(data[1]));
                                    }
                                    break;
                                default:
                                    End = true;
                                    break;

                            }

                            if (End)
                            {
                                break;
                            }
                        }

                    }
                    catch
                    {
                        throw new Exception("Character Load Failed.");
                    }
                }
            }
        }

        /// <summary>
        /// 파일에 캐릭터 데이터를 저장한다.
        /// </summary>
        /// <param name="fileName">캐릭터 파일 이름</param>
        public static void SaveToFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    try
                    {
                        /* * * * Format * * *
                        * MyNickName
                        * 12
                        * 7789
                        * Gunner
                        * 5815
                        * 
                        * [Item]
                        * 붉은 구슬|24
                        * 초콜릿3|21
                        * 비밀상자|1
                        * *
                        * [MountEquipment]
                        * 견고한 투구
                        * 견고한 갑옷
                        * 견고한 부츠
                        * *
                        * [Skill]
                        * 스킬이름1|2
                        * 스킬이름2|12
                        * 스킬이름3|1
                        * *
                        * ***
                        */

                        writer.WriteLine(Name);
                        writer.WriteLine(Level);
                        writer.WriteLine(Exp);
                        writer.WriteLine(Class.Name);
                        writer.WriteLine(Gold);
                        writer.WriteLine();
                        writer.WriteLine("[Item]");
                        foreach (Slot slot in Inventory.Slots)
                        {
                            if (slot.Item == null)
                                continue;

                            writer.WriteLine($"{slot.Item.Name}|{slot.ItemCount}");
                        }
                        writer.WriteLine("*");
                        writer.WriteLine("[MountEquipment]");
                        foreach (Item equipment in MountEquipments.equipments)
                        {
                            writer.WriteLine(equipment.Name);
                        }
                        writer.WriteLine("*");
                        writer.WriteLine("[Skill]");
                        foreach (SkillSlot skillSlot in SkillBook.Slots)
                        {
                            if (skillSlot.Skill == null)
                                continue;

                            writer.WriteLine($"{skillSlot.Skill.Name}|{skillSlot.SkillLevel}");
                        }
                        writer.WriteLine("*");
                        writer.WriteLine("***");

                        writer.Flush();
                    }
                    catch
                    {
                        throw new Exception("Character Save Failed.");
                    }
                }
            }
        }
    }
}
